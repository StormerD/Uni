namespace SwinAdventure {
  public class Bag : Item, IHaveInventory {
    // fields
    private Inventory _inventory;

    // constructors
    public Bag(string[] ids, string name, string description) : base(ids, name, description) {
      _inventory = new Inventory();
    }

    // methods
    public GameObject? Locate(string id) {
      if (AreYou(id)) {
        return this;
      } else if (_inventory.HasItem(id)) {
        return _inventory.Fetch(id);
      } else {
        return null;
      }
    }

    // properties
    public Inventory Inventory {
      get {
        return _inventory;
      }
    }

    public override string FullDescription {
      get {
        return "In the " + Name + " you can see:\n" + Inventory.ItemList;
      }
    }
  }
}