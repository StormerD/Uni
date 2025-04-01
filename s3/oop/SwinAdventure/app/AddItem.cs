// AddItem(Item[]: items)
// AddToList(Item: newItem)
// CheckInList(Item: newItem): bool

namespace SwinAdventure {
    public class AddItem {
        // fields
        private List<Item> _items;
        private bool _inList;
        private int _isInList;

        // defines AddItem constructor
        public AddItem(Item[] items) {
            _items = new List<Item>();
            foreach (Item i in items) {
                _items.Add(i);
            }
        }

        // defines AddItem method
        public void AddToList(Item newItem) {
            _inList = false;
            foreach (Item i in _items) {
                if (i.FirstId == newItem.FirstId) {
                    _inList = false;
                }
            }
            if (!_inList) {
                _items.Add(newItem);
            }
        }

        // defines GetItemName method
        public int CheckInList(Item newItem) {
            foreach (Item i in _items) {
                _isInList = 0;
                if (i.FirstId == newItem.FirstId) {
                    _isInList++;
                }
            }
            return _isInList;
        }
    }
}