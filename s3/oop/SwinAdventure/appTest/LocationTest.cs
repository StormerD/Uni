namespace SwinAdventure {
  public class LocationTest {
    // fields
    Location myRoom;
    Location myRoom2;
    Location myRoom3;
    Item coin;
    Item key;
    Path myRoomNorth;
    Path myRoomEast;

    [SetUp]
    public void SetUp() {
      myRoom = new Location("room", "A small room");
      myRoom2 = new Location("room", "A large room");
      myRoom3 = new Location("garage", "A small garage");
      myRoomNorth = new Path(new string[] { "north" }, "door", "An old wooden door", myRoom, myRoom2, false);
      myRoomEast = new Path(new string[] { "east" }, "gate", "A rusted metal gate", myRoom, myRoom3, false);
      coin = new Item(new string[] { "coin", "gold" }, "gold coin", "a shiny gold coin");
      key = new Item(new string[] { "key", "silver" }, "silver key", "a shiny silver key");
    }
    [Test]
    public void TestItemLocate() {
      myRoom.Inventory.Put(coin);
      myRoom.Inventory.Put(key);
      Assert.That(myRoom.Locate("coin"), Is.EqualTo(coin));
      Assert.That(myRoom.Locate("key"), Is.EqualTo(key));
    }
    [Test]
    public void TestPathLocate() {
      myRoom.AddPath(myRoomNorth);
      myRoom.AddPath(myRoomEast);
      Assert.That(myRoom.Locate("north"), Is.EqualTo(myRoomNorth));
      Assert.That(myRoom.Locate("east"), Is.EqualTo(myRoomEast));
    }
    [Test]
    public void TestNoItemLocate() {
      myRoom.Inventory.Put(coin);
      myRoom.Inventory.Put(key);
      Assert.That(myRoom.Locate("axe"), Is.EqualTo(null));
    }
    [Test]
    public void TestNoPathLocate() {
      myRoom.AddPath(myRoomNorth);
      myRoom.AddPath(myRoomEast);
      Assert.That(myRoom.Locate("south"), Is.EqualTo(null));
    }
    [Test]
    public void TestAddPath() {
      myRoom.AddPath(myRoomNorth);
      myRoom.AddPath(myRoomEast);
      Assert.That(myRoom.PathList, Is.EqualTo("\nThere are exits to the north, and east."));
    }
    [Test]
    public void TestFullDescription() {
      myRoom.AddPath(myRoomNorth);
      myRoom.AddPath(myRoomEast);
      myRoom.Inventory.Put(coin);
      myRoom.Inventory.Put(key);
      Assert.That(myRoom.FullDescription, Is.EqualTo("You are in a room. A small room.\nIn the room you see:\ngold coin (coin), silver key (key)\nThere are exits to the north, and east."));
    }
    [Test]
    public void TestShortDescription() {
      Assert.That(myRoom.ShortDescription, Is.EqualTo("You are in a room"));
    }
    [Test]
    public void TestItemList() {
      myRoom.Inventory.Put(coin);
      myRoom.Inventory.Put(key);
      Assert.That(myRoom.ItemList, Is.EqualTo("In the room you see:\ngold coin (coin), silver key (key)"));
    }
    [Test]
    public void TestNoItemList() {
      Assert.That(myRoom.ItemList, Is.EqualTo("There are no items here."));
    }
  }
}