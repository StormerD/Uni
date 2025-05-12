namespace SwinAdventure {
    public class InventoryTest {
        // fields
        private Item _item1;
        private Item _item2;
        private Inventory _inventory;


        [SetUp] // Setup
        public void SetUp() {
            _item1 = new Item(new string[] {"axe", "stone"}, "a stone axe", "a stone axe used to chop trees");
            _item2 = new Item(new string[] {"sword", "iron", "weapon"}, "an iron sword", "an iron sword used to slay monsters");
            _inventory = new Inventory();
        }

        [Test] // TEST 1: pass if item is in inventory
        public void TestFindItem() {
            _inventory.Put(_item1);
            Assert.That(_inventory.HasItem(_item1.FirstId), Is.True);
        }

        [Test] // TEST 2: pass if item is not in inventory
        public void TestHasNoItemFind() {
            Assert.That(_inventory.HasItem(_item1.FirstId), Is.False);
        }

        [Test] // TEST 3: pass if item is returned and still in inventory
        public void TestFetchItem() {
            _inventory.Put(_item1 );
            Assert.That(_inventory.Fetch(_item1 .FirstId), Is.EqualTo(_item1 ));
            Assert.That(_inventory.HasItem(_item1 .FirstId), Is.True);
        }

        [Test] // TEST 4: pass if item is returned and not in inventory
        public void TestTakeItem() {
            Assert.That(_inventory.HasItem("axe"), Is.False);
            Assert.That(_inventory.Take(_item1 .FirstId), Is.Null);
            _inventory.Put(_item1 );
            Assert.That(_inventory.Take(_item1 .FirstId), Is.EqualTo(_item1 ));
            Assert.That(_inventory.HasItem("axe"), Is.False);
        }

        [Test] // TEST 5: pass if returns item short description
        public void TestItemList() {
            _inventory.Put(_item1 );
            Assert.That(_inventory.ItemList, Is.EqualTo("a stone axe (axe)"));
        }

        [Test] // TEST 6: pass if only one short description
        public void TestUniqueItem() {
            _inventory.Put(_item1 );
            Assert.That(_inventory.ItemList, Is.EqualTo("a stone axe (axe)"));
            _inventory.Put_UniqueItem(_item1 );
            Assert.That(_inventory.ItemList, Is.EqualTo("a stone axe (axe)"));
        }

        [Test] // TEST 7: pass if item < 3 ids is added but item with >= 3 ids is not added
        public void TestPut_ItemWithLimit() {
            _inventory.Put_ItemWithLimit(_item1);
            Assert.That(_inventory.HasItem(_item1.FirstId), Is.True);
            _inventory.Put_ItemWithLimit(_item2);
            Assert.That(_inventory.HasItem(_item2.FirstId), Is.False);
        }
    }
}