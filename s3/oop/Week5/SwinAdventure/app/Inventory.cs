namespace SwinAdventure {
// Inventory()
// HasItem(string : id) : bool
// Put(Item : itm) : void
// Put_UniqueItem(Item : itm) : void
// Put_ItemWithLimit(Item : itm) : void
// Fetch(string : id) : Item / Null
// Take(string : id) : Item / Null
// ItemList : string
    public class Inventory {
        // fields
        private List<Item> _items;
        private bool _inList;

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
        // adds passed item to inventory
        public void Put(Item itm) {
            _items.Add(itm);
        }

        // defines Put_UniqueItem method
        // adds passed item to inventory if it is not in there already
        public void Put_UniqueItem(Item itm) {
            _inList = false;
            foreach (Item i in _items) {
                if (i.FirstId == itm.FirstId) {
                    _inList = true;
                }
            }
            if (!_inList) {
                Put(itm);
            }
        }

        // defines Put_ItemWithLimit method
        // adds item to inventory if it has fewer than 3 ids
        public void Put_ItemWithLimit(Item itm) {
            if (itm.IdCount < 3) {
                Put(itm);
            }
        }

        // defines Fetch method
        // locates item from passed id and returns item
            public Item? Fetch(string id) {
            foreach (Item item in _items) {
                if (item.AreYou(id)) {
                    return item;
                }
            }
            return null;
        }

        // defines Take method
        // removes item from list using passed id and returns removed item
        public Item? Take(string id) {
            foreach (Item item in _items) {
                if (item.AreYou(id)) {
                    _items.Remove(item);
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
                    output += $"\t{item.ShortDescription}";
                }
                return output;
            }
        }
    }
}