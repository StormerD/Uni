namespace SwinAdventure {
  public class BagTest {
    // fields
    private Bag _testBag1, _testBag2;
    private Item _testItem1, _testItem2;

    [SetUp]
    public void SetUp() {
      _testBag1 = new Bag(new string[] {"bag", "leather"}, "a leather bag", "a leather bag used to hold items");
      _testBag2 = new Bag(new string[] {"bag2", "cloth"}, "a cloth bag", "a cloth bag used to hold items");
      _testItem1 = new Item(new string[] {"sword", "iron", "weapon"}, "an iron sword", "an iron sword used for slaying monsters");
      _testItem2 = new Item(new string[] {"axe", "stone"}, "a stone axe", "a stone axe used to chop trees");
    }

    [Test]
    public void TestLocateItems() {
      _testBag1.Inventory.Put(_testItem1);
      Assert.That(_testBag1.Locate(_testItem1.FirstId), Is.EqualTo(_testItem1));
    }

    [Test]
    public void TestLocateSelf() {
      Assert.That(_testBag1.Locate("bag"), Is.EqualTo(_testBag1));
    }

    [Test]
    public void TestLocateNothing() {
      Assert.That(_testBag1.Locate("Gem"), Is.EqualTo(null));
    }

    [Test]
    public void TestBagInBag() {
      _testBag1.Inventory.Put(_testBag2);
      Assert.That(_testBag1.Locate("bag2"), Is.EqualTo(_testBag2));
      _testBag1.Inventory.Put(_testItem1);
      Assert.That(_testBag1.Locate(_testItem1.FirstId), Is.EqualTo(_testItem1));
       _testBag2.Inventory.Put(_testItem2);
      Assert.That(_testBag1.Locate(_testItem2.FirstId), Is.EqualTo(null));
    }

    [Test]
    public void TestBagInBagWithPrivilegedItem() {
      _testBag1.Inventory.Put(_testBag2);
      _testItem1.PrivilegeEscalation("1089");
      _testBag2.Inventory.Put(_testItem1);
      Assert.That(_testBag1.Locate(_testItem1.FirstId), Is.EqualTo(null));
    }
  }
}