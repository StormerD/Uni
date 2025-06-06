﻿using SwinAdventure;
namespace MainProgram {
  class MainClass {
    
    public static void Space(){
      Console.WriteLine("- - - - - - - - - -");
      return;
    }
    public static void Main(string[] args) {
      // set up game conditions
      Console.Clear();
      bool finished = false;
      LookCommand lcmd = new(new string[] { "" });
      MoveCommand mcmd = new(new string[] { "" });
      string help = "Commands: look, move, help, exit\nLook: 'look at [something] (in [something])'\nMove: 'move [direction]'\nDrop: 'drop [item]'\nHelp: 'help'\nExit: 'exit'";

      List<IHaveInventory> myContainers = new List<IHaveInventory>();

      // game init
      Space();
      Console.WriteLine("Welcome to SwinAdventure!\nSetting up your character...");
      Space();
      // - - - - - - - - - - 

      // init locations
      Location myRoom = new Location("room", "A small room");
      Location myYard = new Location("yard", "A small grass yard");

      // MY ROOM PATHS
      SwinAdventure.Path myRoomNorth = new SwinAdventure.Path(new string[] {"north"}, "door", "A wooden door", myRoom, myYard, false);
      SwinAdventure.Path myRoomEast = new SwinAdventure.Path(new string[] {"east"}, "gate", "A locked metal gate", myRoom, null, true);
      myRoom.AddPath(myRoomNorth);
      myRoom.AddPath(myRoomEast);
      // MY YARD PATHS
      SwinAdventure.Path myYardSouth = new SwinAdventure.Path(new string[] {"south"}, "door", "A wooden door", myYard, myRoom, false);
      myYard.AddPath(myYardSouth);
      // - - - - - - - - - -

      // define player object
      string? _pname;
      string? _pdesc;
      while (true) {
        Console.WriteLine("\nName: ");
        _pname = Console.ReadLine();
        if (_pname == "") {
          Console.WriteLine("Please enter a valid name.");
          continue;
        }
        break;
      }
      while (true) {
        Console.WriteLine("Description: ");
        _pdesc = Console.ReadLine();
        if (_pdesc == "") {
          Console.WriteLine("Please enter a valid description.");
          continue;
        }
        break;
      }
      Player player = new Player(_pname, _pdesc);
      player.Location = myRoom;
      Console.WriteLine("\nPlayer created!");
      Console.WriteLine(player.ShortDescription);
      Space();
      // - - - - - - - - - - 

      // init inventory
      Bag bag;
      Item silver;
      Item gold;
      Item sword;
      Item axe;
      Item torch;
      Item waterskin;

      bag = new Bag(new string[] { "bag" }, "Leather Bag", "A leather bag used to store items");
      silver = new Item(new string[] { "silver" }, "Silver Coin", "A not so valuable piece of currency");
      gold = new Item(new string[] { "gold" }, "Gold Coin", "A valuable piece of currency");
      sword = new Item(new string[] { "sword" }, "Steel Sword", "A sharp steel sword");
      axe = new Item(new string[] { "axe" }, "Wooden Axe", "A wooden axe used for chopping wood");
      torch = new Item(new string[] { "torch", "light" }, "Torch", "A torch to light the path");
      waterskin = new Item(new string[] { "waterskin", "water" }, "Waterskin", "A leather skin filled with water");

      for (int i = 0; i < 150; i++) {
        player.Inventory.Put(silver);
      }
      for (int i = 0; i < 500; i++) {
        player.Inventory.Put(gold);
      }
      player.Inventory.Put(bag);
      player.Inventory.Put(sword);
      player.Inventory.Put(torch);

      bag.Inventory.Put(waterskin);
      for (int i = 0; i < 100; i++) {
        bag.Inventory.Put(silver);
      }
      bag.Inventory.Put(gold);
      bag.Inventory.Put(axe);
      // - - - - - - - - - -

      // user input loop
      while (!finished) {
        Console.WriteLine("Enter a command: ");
        string? command = Console.ReadLine();
        if (command == null) {
          Console.WriteLine("Please enter a command. View commands by typing 'help'.");
          continue;
        }

        string[] split = command.Split(" ");

        if (split[0].ToLower() == "exit" || split[0].ToLower() == "ex") {
          finished = true;
          break;
        }
        else if (split[0].ToLower() == "help") {
          Console.WriteLine(help);
          continue;
        }
        else if (split[0].ToLower() == "look") {
          Console.WriteLine(lcmd.Execute(player, split));
        }
        else if (split[0].ToLower() == "move" || split[0].ToLower() == "go" || split[0].ToLower() == "head" || split[0].ToLower() == "leave" || split[0].ToLower() == "walk") {
          Console.WriteLine(mcmd.Execute(player, split));
        }
        else if (split[0].ToLower() == "drop") {
          player.Inventory.Take(split[1]);
        }
        else {
          Console.WriteLine("Command not recognized. Please use 'help' for list of commands.");
        }
        Space();
        // - - - - - - - - - -
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