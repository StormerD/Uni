namespace SwinAdventure {
  public class Player : GameObject {
    // fields
   private Inventory _inventory;

    // constructors
    public Player(string name, string description) :
    base(new string[] {"me", "inventory"}, name, description) {
      _inventory = new Inventory();
    }

    // methods
    public GameObject? Locate(string id) {
      if (AreYou(id)) {
        return this;
      } else {
        return Inventory.Fetch(id);
      }
    }

    public override void SaveTo(StreamWriter writer) {
      base.SaveTo(writer);
      writer.WriteLine(_inventory.ItemList);
    }

    public override void LoadFrom(StreamReader reader) {
      base.LoadFrom(reader);
      string ItemDescriptionList = reader.ReadLine();
      // print information to console
      Console.WriteLine("Player Information");
      Console.WriteLine(Name);
      Console.WriteLine(ShortDescription);
      Console.WriteLine(ItemDescriptionList);
    }

    // properties
    public Inventory Inventory {
      get {
        return _inventory;
      }
    }

    public override string FullDescription {
      get {
        return $"You are {Name} {base.FullDescription}\n" + "You are carrying: \n" + _inventory.ItemList;
      }
    }
  }
}