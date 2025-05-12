namespace SwinAdventure {
  public class LookCommandTest {
    // fields
    private Command command;
    private Player player;
    private Item coin;
    private Bag bag;
 
    [SetUp]
    public void Setup() {
      command = new LookCommand(new string[] {""});
      player = new("Dylan", "a warrior");
      coin = new(new string[] {"coin", "gold"}, "a golden coin", "A valuable piece of currency");
      bag = new(new string[] {"bag", "leather"}, "a leather bag", "a leather bag used to store items");
    }

    [Test]
    public void TestLookAtPlayer() {
      string output = command.Execute(player, new string[] {"look", "at", "inventory"});
      string expected = "You are Dylan, a warrior\nYou are carrying: ";
      Assert.That(output, Is.EqualTo(expected));
    }

    [Test]
    public void TestLookAtCoin() {
      player.Inventory.Put(coin);
      string output = command.Execute(player, new string[] {"look", "at", "coin"});
      Assert.That(output, Is.EqualTo(coin.FullDescription));
    }

    [Test]
    public void TestLookAtUnk() {
      string output = command.Execute(player, new string[] {"look", "at", "coin"});
      string expected = "I can't find the coin";
      Assert.That(output, Is.EqualTo(expected));
    }

    [Test]
    public void LookAtCoinInMe() {
      player.Inventory.Put(coin);
      string output = command.Execute(player, new string[] {"look", "at", "coin", "in", "inventory"});
      Assert.That(output, Is.EqualTo(coin.FullDescription));
    }

    [Test]
    public void TestLookAtCoinInBag() {
      player.Inventory.Put(bag);
      bag.Inventory.Put(coin);
      string output = command.Execute(player, new string[] {"look", "at", "coin", "in", "bag"});
      Assert.That(output, Is.EqualTo(coin.FullDescription));
    }

    [Test]
    public void TestLookAtCoinInNoBag() {
      bag.Inventory.Put(coin);
      string output = command.Execute(player, new string[] {"look", "at", "coin", "in", "bag"});
      Assert.That(output, Is.EqualTo("I can't find the bag"));
    }
    
    [Test]
    public void TestLookAtNoCoinInBag() {
      player.Inventory.Put(bag);
      string output = command.Execute(player, new string[] {"look", "at", "coin", "in", "bag"});
      Assert.That(output, Is.EqualTo("I can't find the coin"));
    }

    [Test]
    public void TestInvalidLook() {
      // != 3 || 5
      Assert.That(command.Execute(player, new string[] {"Hello", "105341089"}), Is.EqualTo("I don't know how to look like that"));
      // = 3, "look"
      Assert.That(command.Execute(player, new string[] {"Hello", "105341089", "number"}), Is.EqualTo("Error in look input"));
      // =3, "at"
      Assert.That(command.Execute(player, new string[] {"look", "105341089", "number"}), Is.EqualTo("What do you want to look at?"));
      // =5, "in"
      Assert.That(command.Execute(player, new string[] {"look", "at", "coin", "at", "bag"}), Is.EqualTo("What do you want to look in?"));
    }
  }
}