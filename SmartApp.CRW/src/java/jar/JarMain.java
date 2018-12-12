package jar;

import com.sun.webkit.network.URLs;
import elf_crawler.CrawlingManager;
import elf_crawler.URLSet;
import elf_crawler.crawler.DataEntry;
import elf_crawler.crawler.KBTagManager;
import elf_crawler.crawler.Tag;
import elf_crawler.relationship.RelationQuery;
import elf_crawler.relationship.RelationshipSet;
import elf_crawler.util.LogLevel;
import elf_crawler.util.Logger;
import elf_kb_protocol.*;

import java.net.SocketTimeoutException;
import java.util.LinkedList;
import java.util.List;
import java.util.concurrent.ExecutionException;

public class JarMain {

    private static final String FLAGS_STRING =
            "-d <max crawling depth>: the maximum depth that will be crawled.\n" +
                    "-h,-help: prints help\n" +
                    "-host <address>: the host address of the Knowledge Base server\n" +
                    "-host <address> <port>: the host address and port of the Knowledge Base server\n" +
                    "-l,-log,-loglevel <1, 2, 3, error, warn, fine>: sets the logger value. Each number has the same meaning as its respective string. Example: a log level of '1' is the same as 'error'.\n" +
                    "-r,-relations <filename>: relationship set location (required)\n" +
                    "-tag,-taglist <filename>: tag list location (required)\n" +
                    "-t,-threads <numthreads>: how many threads to use in the Crawler. Default is the amount of threads in the CPU\n" +
                    "-u,-urls <filename>: url set location (required)\n";
    private static final String USAGE_STRING = "Usage: <crawler> <flags>\n\nFlags:\n" + FLAGS_STRING;
    private static final int DEFAULT_SLEEP_TIME = 720;


    private static int maxCrawlingDepth = 1;
    private static int threads = Runtime.getRuntime().availableProcessors();
    private static String rsFilename = null;
    private static String urlsetFilename = null;
    private static String taglistFilename = null;
    private static String KBHost = null;
    private static int KBPort = -1;
    private static int sleepTime = -1;

    public static void main(String[] args) throws Exception {
        List<Argument> arg = parseArgs(args);
        processArgs(arg);

        Logger.info(String.format("Using %d threads and a maximum crawling depth of %d.", threads, maxCrawlingDepth));

        RelationshipSet rs = new RelationshipSet(rsFilename);
        URLSet urlSet = new URLSet(urlsetFilename);
        KBTagManager tagm = new KBTagManager(taglistFilename);

        Logger.info("Attempting to create a connection to KB");
        try {
            KBConnection con = new KBConnection(KBHost, KBPort);
            Logger.info("Registering Crawler!");

            TagList jreq = new TagList();
            for (Tag t : tagm.getAllTags()) {
                jreq.addTag(t.getTagName(), t.getDesc(), t.getDoc());
                Logger.info("Registering tag " + t);
            }
            con.registerTags(jreq);

            Logger.info("Crawler entity registered!");

            do
            {
                executeCrawlCycle(rs, urlSet, con, tagm);
                Thread.sleep(sleepTime * 60000);
            } while (sleepTime != -1);

            con.closeConnection();

        } catch (SocketTimeoutException e) {
            Logger.error(String.format("Could not establish connection to: %s:%d", KBHost, KBPort));
            System.exit(-1);
        }

        Logger.info("Crawler has ended successfully!");
    }

    private static void executeCrawlCycle(RelationshipSet rs, URLSet urlSet, KBConnection con, KBTagManager tagm) throws Exception {
        Logger.info("Starting new crawling cycle!");
        CrawlingManager cm = new CrawlingManager(urlSet, rs, maxCrawlingDepth, threads);
        List<DataEntry> dataEntries = cm.executeAllCrawlers();
        cm.shutdown();
        Logger.info("Crawler cycle finished!");

        Logger.info(String.format("Crawled has discovered %d new links.", cm.getNewLinkCount()));

        for (DataEntry d : dataEntries) {
            if (d == null) continue;

            if (!tagm.hasTag(d.tag)) {
                Logger.error("Unregistered tag '" + d.tag + "' found in " + d);
                continue;
            }

            Logger.info("Added entry: " + d);
            con.addFact(new Fact(d.tag, KBTTL.DAY, 100, d));
        }
    }

    private static void processArgs(List<Argument> arg) {
        if (arg.isEmpty())
            Logger.critical(USAGE_STRING);

        for (Argument a : arg) {
            switch (a.flag.toLowerCase()) {

                case "continuous":
                    if (a.values.size() > 1)
                        Logger.critical("Usage:\n-continuous <sleep-time-minutes> Sets the crawler to run continously," +
                                " with a sleep time in minutes between each crawl cycle. You may omit the time, in which " +
                                "case, this will set the default sleep value to 720 minutes.");

                    if (a.values.size() == 1)
                        sleepTime = Integer.parseInt(a.values.get(0));
                    else
                        sleepTime = DEFAULT_SLEEP_TIME;
                    if (sleepTime <= 0)
                        Logger.critical("Sleep time must be positive.");
                    break;
                case "d":
                    if (a.values.size() != 1)
                        Logger.critical("Usage:\n-d <max-crawling-depth> The maximum depth to crawl for.");

                    maxCrawlingDepth = Integer.parseInt(a.values.get(0));

                    if (threads <= 0)
                        Logger.critical("Max crawling depth must be positive");

                    break;

                case "h":
                case "help":
                    System.out.println(USAGE_STRING);
                    System.exit(0);
                case "host":
                    switch (a.values.size()) {
                        case 2:
                            KBPort = Integer.parseInt(a.values.get(1));
                        case 1:
                            KBHost = a.values.get(0);
                            break;
                        default:
                            Logger.critical("Usage:\n-host <hostname> <port>");
                    }

                    break;

                case "l":
                case "log":
                case "loglevel":
                    LogLevel l = LogLevel.fromString(a.values.get(0));
                    if (l == null)
                        Logger.critical("Usage:\n-log,l <1, 2, 3, error, warn, fine>: sets the logger value.");

                    Logger.setLogLevel(LogLevel.fromString(a.values.get(0)));
                    break;

                case "r":
                case "relations":
                    if (a.values.size() != 1)
                        Logger.critical("Usage:\n-r <relationship.json location>");
                    rsFilename = a.values.get(0);

                    break;
                case "tag":
                case "taglist":
                    if (a.values.size() != 1)
                        Logger.critical("Usage:\n -tag,-taglist <filename>");
                    taglistFilename = a.values.get(0);

                    break;

                case "t":
                case "threads":
                    if (a.values.size() != 1)
                        Logger.critical("Usage:\n-t <numthreads>");

                    threads = Integer.parseInt(a.values.get(0));

                    if (threads <= 0)
                        Logger.critical("Number of threads must be positive");

                    break;

                case "u":
                case "urls":
                    if (a.values.size() != 1)
                        error("Usage:\n-s <urlset.json location>");
                    urlsetFilename = a.values.get(0);

                    break;

                default:
                    Logger.critical(String.format("Unrecognized flag '%s'. ", a.flag) + USAGE_STRING);
            }
        }

        if (rsFilename == null)
            Logger.critical("Missing relationshipSet.json location. Please provide the location using the flag -r <filename>");

        if (urlsetFilename == null)
            Logger.critical("Missing urlset.json location. Please provide the location using the flag -u <filename>");

        if (taglistFilename == null)
            Logger.critical("Missing taglist.json location. Please provide the location using the flag -tag,-taglist <filename>");

        if (KBHost == null) {
            Logger.info("No KB host provided! Assuming locahost.");
            KBHost = "ws://localhost";
        }

        if (KBPort < 0) {
            Logger.info("No KB port provided! Assuming default port 5666.");
            KBPort = 5666;
        }
    }

    private static void warning(String message) {
        System.out.println(message);
    }

    private static void error(String message) {
        System.err.println(message);
        System.exit(-1);
    }

    private static List<Argument> parseArgs(String[] args) {
        List<Argument> arg = new LinkedList<>();
        Argument a = null;
        for (String s : args) {
            if (s.startsWith("-")) {
                a = new Argument(s.substring(1, s.length()));
                arg.add(a);
            } else if (a != null) {
                if (s.startsWith("\""))
                    s = s.substring(1, s.length());
                if (s.endsWith("\""))
                    s = s.substring(0, s.length() - 1);
                a.values.add(s);
            }
        }

        return arg;
    }

    static class Argument {
        String flag;
        List<String> values;

        public Argument(String flag) {
            this.flag = flag;
            this.values = new LinkedList<>();
        }

        @Override
        public String toString() {
            return "-" + flag + " " + values.toString();
        }
    }
}
