import pytest

def test_db_len(db):

    assert len(db) == 0

    with pytest.raises(AttributeError):
        db[0] = (1, "ciao", "due")

    with pytest.raises(AttributeError):
        db["1"] = (1, "ciao", "due")

    db[0] = ("ciao", "due")
    db["1"] = ("cip", "ciop")
    assert len(db) == 2

    db.delete((None, None, None))

def test_db_set_get(db):

    db[5] = ("co", "de")
    assert set(db["5"][0]) == set(("5", "co", "de"))
    db[5] = ("coco", "de")
    assert set(db["5"][0]) == set(("5", "coco", "de"))
    db[5] = ("co", "del")
    assert set(db["5"][0]) == set(("5", "co", "del"))

    # get no str
    db[0] = ("ciao", "due")
    db[1] = ("ciaociao", "tre")

    assert set(db[0][0]) == set(("0", "ciao", "due"))
    #get str
    assert set(db["1"][0]) == set( ("1", "ciaociao", "tre"))

    # IndexError if not present
    with pytest.raises(IndexError):
        db["2"]

    db.delete((None, None, None))

def test_db_del(db):

    db[0] = ("ciao", "due")
    db[1] = ("ciaociao", "tre")
    del db[1]
    assert len(db) == 1

    with pytest.raises(IndexError):
        db[1]

    #del string
    db["2"] = ("cip", "ciop")
    del db["2"]

    assert len(db) == 1

    with pytest.raises(IndexError):
        db["1"]

    db.delete((None, None, None))

def test_db_contains(db):

    db["1"] = ("cip", "ciop")
    db["gino"] = ("tre", "porci")

    assert ("1", "cip", "ciop") in db
    assert ("gino", "tre", "porci") in db

    db.delete((None, None, None))

def test_db_get_value(db):

    db["1"] = ("cip", "ciop")
    db["gino"] = ("tre", "porci")

    assert set(db.get_value(1)[0]) == set(("cip", "ciop"))
    assert set(db.get_value("gino")[0]) == set(("tre", "porci"))

    with pytest.raises(IndexError):
        db.get_value("giangiacomo")

    with pytest.raises(IndexError):
        db.get_value("10")

    assert set(db.get_value("gino", 1)[0]) == set(["tre"])
    assert set(db.get_value("gino", 2)[0]) == set(["porci"])

    with pytest.raises(IndexError):
        db.get_value("gino", 3)

    db.insert(("1", "cipi", "ciopi"))
    assert list(db.get_value(1)) == list([["cip", "ciop"],["cipi", "ciopi"]])

    db.delete((None, None, None))

def test_db_soft_get(db):

    db.insert(("1", "cipi", "ciopi"))
    db.insert(("ciopi", "ciopi"))
    db.insert(("cikpi", "ciopik"))
    db.insert((2, "cispiq", "ciopip"))
    db.insert(("cipiss", "ciopi"))

    assert len(db.soft_get((1, "cipi", "ciopi"))) == 1

    db["1"] = (None, "cio")
    db["2"] = (None, "cio")
    assert len(db.soft_get((None, "cio"))) == 2
    assert list(db.soft_get((None, None, "cio"))) == list([[["1", "cipi", "cio"], 1], [["2", "cispiq", "cio"], 1]])

    db["giacomino"] = ("cipi", "gamba")
    assert list(db.soft_get(("cipi", None))) == list([[["1", "cipi", "cio"], 1],[["giacomino", "cipi", "gamba"], 1]])
    assert len(db.soft_get((None, "cipi", None))) == 2

    db.delete((None, None, None))
#
def test_db_soft_contains(db):

    db.insert(("1","cipi", "ciopi"))
    db.insert(("ciopi", "ciopi"))
    db.insert(("cipi", "ciopik"))
    db.insert(("cikpi", "cio"))
    db.insert(("cispiq", "ciopip"))
    db.insert(("cipiss", "ciopi"))

    assert db.soft_contain(1)
    assert db.soft_contain("1")
    assert db.soft_contain((1, "cipi", "ciopi"))
    assert db.soft_contain((None, "cio"))
    assert db.soft_contain((None, "cipi", None))

    assert not db.soft_contain(205)
    assert not db.soft_contain((200, "cipi", None))
    assert not db.soft_contain((None, "fritto", None))
    assert not db.soft_contain((None, "cipolle"))
    db.delete((None, None, None))

def test_db_insert(db):
    db.insert(("1","cipi", "ciopi"))
    db.insert(("ciopi", "ciopi"))
    db.insert(("cipi", "ciopik"))
    db.insert(("cispiq", "ciopip"))
    db.insert(("cipiss", "ciopi"))
    assert len(db) == 5

    gid = db.insert(("matro", "ciccillo"))
    assert len(db) == 6
    # [[[id, desc, token],1]] so [0][0][0]
    id = db.soft_get(("matro", "ciccillo"))[0][0][0]
    assert id == gid

    with pytest.raises(ValueError):
        db.insert(("1", "cipi", "ciopi"))

    db.delete((None, None, None))

def test_db_modify(db):

    db.insert(("4", "monte", "pippo"))
    db.insert(("1", "cip", "cio"))
    db.insert(("0", "ciao", "pula"))
    db.insert(("1", "cipi", "cio"))
    db.insert(("6", "casa", "sasso"))
    db.insert(("7", "cic", "piatto"))
    db.insert(("1", "cipi", "ciopi"))
    l, mod = db.modify(1, ("cic", None))
    assert l == 3
    assert list(mod) == list([["1", "cip", "cio"], ["1", "cipi", "cio"], ["1", "cipi", "ciopi"]])
    assert list(db.soft_get((1, "cic", None))) == list([[["1", "cic", "cio"], 1], [["1", "cic", "ciopi"], 1]])

    l, mod = db.modify((1, "cic", None), (35, "c0c", None))
    assert l == 2
    assert list(mod) == list([["1", "cic", "cio"], ["1", "cic", "ciopi"]])
    assert list(db.soft_get((35, "c0c", None))) == list([[["35", "c0c", "cio"], 1], [["35", "c0c", "ciopi"], 1]])

    db.delete((None, None, None))

def test_db_delete(db):

    db.insert(("1", "cic", "cio"))
    db.insert(("2", "cicoooo", "cio"))
    db.insert(("3", "caos", "purga"))
    db.insert(("4", "monte", "pippo"))
    db.insert(("0", "ciao", "pula"))
    db.insert(("6", "casa", "sasso"))
    db.insert(("7", "cic", "piatto"))
    db.insert(("35", "cis", "ora"))

    n, el = db.delete((None, None, "cio"))
    assert n == 2
    assert len(db) == 6

    n, el = db.delete(10)
    assert n == 0
    assert len(db) == 6

    n, el = db.delete(35)
    assert n == 1
    assert len(db) == 5

    n, el = db.delete((0, "ciao", None))
    assert n == 1
    assert len(db) == 4

    db.delete((None, None, None)) == 4
    assert len(db) == 0

    db.delete((None, None, None))
