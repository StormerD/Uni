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

        [Test] // TEST 1
        public void TestFindItem() {
            _inventory.Put(_item);
            Assert.That(_inventory.HasItem(_item.FirstId), Is.True);
        }

        [Test] // TEST 2
        public void TestHasNoItemFind() {
            Assert.That(_inventory.HasItem("sword"), Is.False);
        }

        [Test] // TEST 3
        public void TestFetchItem() {
            _inventory.Put(_item);
            Assert.That(_inventory.Fetch(_item.FirstId), Is.EqualTo(_item));
            Assert.That(_inventory.HasItem(_item.FirstId), Is.True);
        }

        [Test] // TEST 4
        public void TestTakeItem() {
            Assert.That(_inventory.HasItem("axe"), Is.False);
            _inventory.Put(_item);
            Assert.That(_inventory.Take(_item.FirstId), Is.EqualTo(_item));
            Assert.That(_inventory.HasItem("axe"), Is.False);
        }

        [Test] // TEST 5
        public void TestItemList() {
            _inventory.Put(_item);
            Assert.That(_inventory.ItemList, Is.EqualTo("\ta stone axe (axe)"));
        }
    }
}