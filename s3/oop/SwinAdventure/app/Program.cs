using SwinAdventure;
namespace MainProgram {
  class MainClass {
    public static void Main(string[] args) {
      // set up game conditions
      bool finished = false;
      LookCommand cmd = new(new string[] {""});

      List<IHaveInventory> myContainers = new List<IHaveInventory>();

      // define player object
      Player player;
      player = new Player("Dylan", "a warrior");

      // define a bag
      Bag bag;
      bag = new Bag(new string[] {"bag", "leather"}, "Leather Bag", "A leather bag used to store items");

      // define an item
      Item coin;
      coin = new Item(new string[] {"coin", "gold"}, "Gold Coin", "A valuable piece of currency");

      // put items in inventories
      bag.Inventory.Put(coin);
      bag.Inventory.Put(coin);
      player.Inventory.Put(bag);
      player.Inventory.Put(coin);

      // user input loop
      while (!finished) {
        Console.WriteLine("Enter a command");
        string command = Console.ReadLine();

        if (command.ToLower() == "exit") {
          finished = true;
          break;
        }

        string[] split = command.Split(" ");

        Console.WriteLine(cmd.Execute(player, split));
      } 
      

      // - - - - - - - - - -

      // Console.WriteLine(player.ShortDescription);
      // Console.WriteLine(player.FullDescription);
      // Console.WriteLine(bag.ShortDescription);
      // Console.WriteLine(bag.FullDescription);
      // Console.WriteLine(coin.ShortDescription);
      // Console.WriteLine(coin.FullDescription);

      // - - - - - - - - - -

      // add bag to list of containers
      // myContainers.Add(player);
      // myContainers.Add(toolBag);

      // for loop to print out objects
      // foreach (IHaveInventory container in myContainers) {
      //   if (container is Player p) {
      //     Console.WriteLine(p.Name);
      //   } else if (container is Bag b) {
      //     Console.WriteLine(b.Name);
      //   }
      // }

      // - - - - - - - - - -

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

      // - - - - - - - - - -

      // write PlayerObject to file
      // StreamWriter writer = new StreamWriter("TestPlayer.txt");
      // try {
      //   Console.WriteLine("-- Saving Data --");
      //   player.SaveTo(writer);
      // } finally {
      //   writer.Close();
      // }

      // // write PlayerObject to file
      // StreamReader reader = new StreamReader("TestPlayer.txt");
      // try {
      //   Console.WriteLine("-- Loading Data --");
      //   player.LoadFrom(reader);
      // } finally {
      //   reader.Close();
      // }
    }
  }
}