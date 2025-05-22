namespace SwinAdventure {
  public class Player : GameObject, IHaveInventory {
    // fields
    private Inventory _inventory;
    private Location _location;

    // constructors
    public Player(string name, string desc) :
    base(new string[] { "me", "inventory" }, name, desc) {
      _inventory = new Inventory();
    }

    // methods
    public GameObject? Locate(string id) {
      if (AreYou(id)) {
        return this;
      }
      GameObject obj = Inventory.Fetch(id);
      if (obj != null) {
        return obj;
      }
      if (Location != null) {
        return Location.Locate(id);
      }
      else {
        return null;
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

    public Location Location {
      get {
        return _location;
      }
      set {
        _location = value;
      }
    }

    public override string FullDescription {
      get {
        return $"You are {Name}, {base.FullDescription}\n" + "You are carrying: " + _inventory.ItemList;
      }
    }
  }
}