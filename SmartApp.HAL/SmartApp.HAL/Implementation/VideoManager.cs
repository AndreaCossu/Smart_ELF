﻿using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SmartApp.HAL.Implementation;
using SmartApp.HAL.Services;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using SmartApp.HAL.Model;
using Google.Protobuf;

namespace SmartApp.HAL.Implementation
{
    internal class VideoManager : IVideoManager
    {
        private readonly IVideoSource _source;
        private readonly INetwork _network;
        private readonly ILogger<VideoManager> _logger;

        public VideoManager(IVideoSource source, INetwork network, ILogger<VideoManager> logger)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
            _network = network ?? throw new ArgumentNullException(nameof(network));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Start()
        {
            _source.FrameReady += (_, frame) =>
            {
                // Exit immediately if we did not find any face
                if (frame.Faces.Count == 0)
                {
                    return;
                }

                // Prepare the packet to send over the net
                var packet = new VideoDataPacket() {
                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                };
                foreach (var face in frame.Faces)
                {
                    var buf = new byte[face.Bounds.Width * face.Bounds.Height * 3];
                    for (var y = 0; y < face.Bounds.Height; y++)
                    {
                        for (var x = 0; x < face.Bounds.Width; x++)
                        {
                            for (var c = 0; c < 3; c++)
                            {
                                buf[(y * face.Bounds.Width + x) * 3 + c] = frame.Image.Data[y + face.Bounds.Top, x + face.Bounds.Left, c];
                            }
                        }
                    }

                    File.WriteAllBytes(@"C:\users\marco\desktop\test.raw", buf);
                    _logger.LogInformation("{0}x{1}", face.Bounds.Width, face.Bounds.Height);

                    packet.Faces.Add(new VideoDataPacket.Types.Face() {
                        Id = -1,
                        Data = ByteString.CopyFrom(buf),
                        Rect = new VideoDataPacket.Types.Rectangle() {
                            Top = face.Bounds.Top,
                            Left = face.Bounds.Left,
                            Width = face.Bounds.Width,
                            Height = face.Bounds.Height
                        }
                    });
                }

                _network.SendPacket(packet);

            };
        }
    }
}
