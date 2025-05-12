using SwinAdventure;
namespace MainProgram {
  class MainClass {
    public static void Main(string[] args) {
      List<IHaveInventory> myContainers = new List<IHaveInventory>();

      // define player object and add it to containers list
      Player _testPlayer;
      _testPlayer = new Player("Dylan", "a warrior");

      myContainers.Add(_testPlayer);

      // define a bag and an item and add the item into the inventory of the bag
      Bag _testToolBag;
      _testToolBag = new Bag(new string[] {"bang", "tool"}, "Tools Bag", "A bag that contains tools");
      Item _testItem1;
      _testItem1 = new Item(new string[] {"stew", "beef"}, "A Beef Stew", "A hearty beef stew");

      _testToolBag.Inventory.Put(_testItem1);

      // add bag to list of containers
      myContainers.Add(_testToolBag);

      // for loop to print out objects
      foreach (IHaveInventory container in myContainers) {
        if (container is Player player) {
          Console.WriteLine(player.Name);
        } else if (container is Bag bag) {
          Console.WriteLine(bag.Name);
        }
      }

      // Console.WriteLine("Hello World!");

      // Item item1 = new Item(new string[] {"silver", "hat"}, "A Silver Hat", "A very shiny silver hat");
      // Item item2 = new Item(new string[] {"light", "torch"}, "A Torch", "A torch to light the path");

      // // add the items into the player's inventory
      // _testPlayer.Inventory.Put(item1);
      // _testPlayer.Inventory.Put(item2);

      // // print the player ids
      // Console.WriteLine(_testPlayer.AreYou("me"));
      // Console.WriteLine(_testPlayer.AreYou("inventory"));

      // if (_testPlayer.Locate("torch") != null) {
      //   Console.WriteLine("The object torch exists");
      //   Console.WriteLine(_testPlayer.Inventory.HasItem("torch"));
      // } else {
      //   Console.WriteLine("The object torch does not exist");
      // }
      // Console.WriteLine(_testPlayer.FullDescription);

      // write PlayerObject to file
      StreamWriter writer = new StreamWriter("TestPlayer.txt");
      try {
        Console.WriteLine("-- Saving Data --");
        _testPlayer.SaveTo(writer);
      } finally {
        writer.Close();
      }

      // write PlayerObject to file
      StreamReader reader = new StreamReader("TestPlayer.txt");
      try {
        Console.WriteLine("-- Loading Data --");
        _testPlayer.LoadFrom(reader);
      } finally {
        reader.Close();
      }
    }
  }
}