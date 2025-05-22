namespace SwinAdventure {
  public class PathTest {
    // fields
    Path _path;
    Location _origin;
    Location _destination;
    Player _player;

    [SetUp]
    public void SetUp() {
      _origin = new Location("room", "A small room");
      _destination = new Location("room", "A large room");
      _path = new Path(new string[] { "north" }, "door", "An old wooden door", _origin, _destination, false);
      _player = new Player("Player", "A player");
    }
    [Test]
    public void TestMove() {
      _player.Location = _origin;
      _path.Move(_player);
      Assert.That(_player.Location, Is.EqualTo(_destination));
    }
    [Test]
    public void TestMoveBlocked() {
      _path.IsBlocked = true;
      _player.Location = _origin;
      _path.Move(_player);
      Assert.That(_player.Location, Is.EqualTo(_origin));
    }
    [Test]
    public void TestShortDescription() {
      Assert.That(_path.ShortDescription, Is.EqualTo("door"));
    }
    [Test]
    public void TestUnlock() {
      _path.IsBlocked = true;
      Assert.That(_path.IsBlocked, Is.EqualTo(true));
      _path.IsBlocked = false;
      Assert.That(_path.IsBlocked, Is.EqualTo(false));
    }
  }
}

