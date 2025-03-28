namespace SwinAdventure {
    public class InventoryTest {
        // fields
        private Item _item;
        private Inventory _inventory;


        [SetUp] // Setup
        public void SetUp() {
            _item = new Item(new string[] {"axe", "stone"}, "stone axe", "a stone axe used to chop trees");
            _inventory = new Inventory();
        }

        [Test] // TEST 1: pass if item is in inventory
        public void TestFindItem() {
            _inventory.Put(_item);
            Assert.That(_inventory.HasItem(_item.FirstId), Is.True);
        }

        [Test] // TEST 2: pass if item is not in inventory
        public void TestHasNoItemFind() {
            Assert.That(_inventory.HasItem(_item.FirstId), Is.False);
        }

        [Test] // TEST 3: pass if item is returned and still in inventory
        public void TestFetchItem() {
            _inventory.Put(_item);
            Assert.That(_inventory.Fetch(_item.FirstId), Is.EqualTo(_item));
            Assert.That(_inventory.HasItem(_item.FirstId), Is.True);
        }

        [Test] // TEST 4: pass if item is returned and not in inventory
        public void TestTakeItem() {
            Assert.That(_inventory.HasItem("axe"), Is.False);
            Assert.That(_inventory.Take(_item.FirstId), Is.Null);
            _inventory.Put(_item);
            Assert.That(_inventory.Take(_item.FirstId), Is.EqualTo(_item));
            Assert.That(_inventory.HasItem("axe"), Is.False);
        }

        [Test] // TEST 5: pass if returns item short description
        public void TestItemList() {
            _inventory.Put(_item);
            Assert.That(_inventory.ItemList, Is.EqualTo("\ta stone axe (axe)"));
        }

        [Test] // TEST 6: pass if only one short description
        public void TestUniqueItem() {
            _inventory.Put(_item);
            Assert.That(_inventory.ItemList, Is.EqualTo("\ta stone axe (axe)"));
            _inventory.Put_UniqueItem(_item);
            Assert.That(_inventory.ItemList, Is.EqualTo("\ta stone axe (axe)"));
        }
    }
}