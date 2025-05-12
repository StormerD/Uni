namespace SwinAdventure {
  public class PlayerTest {
    // fields
    private Item _testItem1;
    private Item _testItem2;
    private Player _testPlayer;

    [SetUp]
    public void Setup() {
      _testPlayer = new Player("Dylan", "a warrior");
      _testItem1 = new Item(new string[] {"silver", "hat"}, "a Silver Hat", "A very shiny silver hat");
      _testItem2 = new Item(new string[] {"light", "torch"}, "a Torch", "A torch to light the path");
      _testPlayer.Inventory.Put(_testItem1);
      _testPlayer.Inventory.Put(_testItem2);
    }

    [Test]
    public void TestIdentifiablePlayer() {
      Assert.That(_testPlayer.AreYou("me"), Is.True);
    }

    [Test]
    public void TestLocatePlayer() {
      Assert.That(_testPlayer.Locate("me"), Is.EqualTo(_testPlayer));
    }

    [Test]
    public void TestLocateItems() {
      Assert.Multiple(() => {
        Assert.That(_testPlayer.Locate("hat"), Is.EqualTo(_testItem1));
        Assert.That(_testPlayer.Locate("torch"), Is.EqualTo(_testItem2));
      });
    }

    [Test]
    public void TestLocateNothing() {
      Assert.That(_testPlayer.Locate(""), Is.Null);
    }

    [Test]
    public void TestPlayerFullDescription() {
      Assert.That(_testPlayer.FullDescription, Is.EqualTo("You are Dylan a warrior\nYou are carrying: \na Silver Hat (silver), a Torch (light)"));
    }
  }
}