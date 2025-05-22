namespace SwinAdventure{
  public class Location : GameObject, IHaveInventory {
    // fields
    private Inventory _inventory;
    private List<Path> _paths;

    // constructor
    public Location(string name, string desc) : base(new string[] {"location"}, name, desc) {
      _inventory = new Inventory();
      _paths = new List<Path>();
    }

    public Location(string name, string desc, List<Path> paths) : this(name, desc) {
      _paths = paths;
    }

    // methods
    public GameObject Locate(string id) {
      if (AreYou(id)) {
        return this;
      }
      foreach (Path path in _paths) {
        if (path.AreYou(id)) {
          return path;
        }
      }
      return Inventory.Fetch(id);
    }

    public void AddPath(Path path) {
      _paths.Add(path);
    }

    // properties
    public Inventory Inventory {
      get { return _inventory; }
    }

    public string PathList {
      get {
        string list = "\n";
        if (_paths.Count == 1) {
          return "There is an exit " + _paths[0].FirstId + ".";
        }
        list = list + "There are exits to the ";
        for (int i = 0; i < _paths.Count; i++) {
          if (i == _paths.Count - 1) {
            list = list + "and " + _paths[i].FirstId + ".";
          }
          else {
            list = list + _paths[i].FirstId + ", ";
          }
        }
        return list;
      }
    }

    public string ItemList {
      get {
        if (_inventory.ItemCount == 0) {
          return "There are no items here.";
        }
        else {
          return "In the room you see:\n" + _inventory.ItemList;
        }
      }
    }

    public override string ShortDescription {
      get {
        return "You are in a " + Name;
      }
    }

    public override string FullDescription {
      get {
        string nameDescription;
        string inventoryDescription;

        if (Name != null && Name != "") {
          nameDescription = Name;
        }
        else {
          nameDescription = " an unnamed location";
        }

        return "You are in a " + nameDescription + ". " + base.FullDescription + ".\n" + ItemList  + PathList;
      }
    }
  }
}