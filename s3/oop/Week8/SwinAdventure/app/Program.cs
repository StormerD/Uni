using SwinAdventure;
namespace MainProgram {
  class MainClass {
    public static void Main(string[] args) {
      Console.WriteLine("Hello World!");

      Player _testPlayer;
      _testPlayer = new Player("Dylan", "a warrior");

      Item item1 = new Item(new string[] {"silver", "hat"}, "A Silver Hat", "A very shiny silver hat");
      Item item2 = new Item(new string[] {"light", "torch"}, "A Torch", "A torch to light the path");

      // add the items into the player's inventory
      _testPlayer.Inventory.Put(item1);
      _testPlayer.Inventory.Put(item2);

      // print the player ids
      Console.WriteLine(_testPlayer.AreYou("me"));
      Console.WriteLine(_testPlayer.AreYou("inventory"));

      if (_testPlayer.Locate("torch") != null) {
        Console.WriteLine("The object torch exists");
        Console.WriteLine(_testPlayer.Inventory.HasItem("torch"));
      } else {
        Console.WriteLine("The object torch does not exist");
      }
      Console.WriteLine(_testPlayer.FullDescription);

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