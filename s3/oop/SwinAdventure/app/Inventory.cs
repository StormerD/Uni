namespace SwinAdventure {
// Inventory()
// Inventory.HasItem(string: id): bool
// Inventory.Put(Item: itm)
// Inventory.Take(string: id): Item
// Inventory.Fetch(string: id): Item
    public class Inventory {
        // fields
        private List<Item> _items;

        // defines Inventory constructor
        public Inventory() {
            _items = new List<Item>();
        }

        // defines HasItem method
        // checks if inventory has item with passed id and returns bool
        public bool HasItem(string id) {
            foreach (Item i in _items) {
                if (i.AreYou(id)) {
                    return true;
                }
            }
            return false;
        }

        // defines Put method
        // adds passed id to inventory
        public void Put(Item itm) {
            _items.Add(itm);
        }

        // defines Take method
        // removes item from list using passed id and returns removed item
        public Item Take(string id) {
            foreach (Item item in _items) {
                if (item.AreYou(id)) {
                    _items.Remove(item);
                    return item;
                }
            }
            return null;
        }

        // defines Fetch method
        // locates item from passed id and returns item
            public Item Fetch(string id) {
            foreach (Item item in _items) {
                if (item.AreYou(id)) {
                    return item;
                }
            }
            return null;
        }

        // defines ItemList property
        public string ItemList {
            get {
                string output = "";
                foreach (Item item in _items) {
                    output += ($"\t{item.ShortDescription}");
                }
                return output;
            }
        }
    }
}