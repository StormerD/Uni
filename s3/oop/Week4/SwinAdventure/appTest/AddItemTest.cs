namespace SwinAdventure {
    public class AddItemTest {
        // TEST variables
        private Item _stone_Sword;
        private Item _stone_Pickaxe;
        private Item _stone_Axe;
        private AddItem Inventory;
        private Item[] _items;

        [SetUp]
        public void Setup() {
            // TEST Setup
            _stone_Sword = new Item(new string[] { "sword", "stone", "weapon" }, "stone sword", "a sharp stone sword used to slay monsters");
            _stone_Pickaxe = new Item(new string[] { "pickaxe", "stone", "tool" }, "stone pickaxe", "a stone pickaxe used to mine ores");
            _stone_Axe = new Item(new string[] { "axe", "stone", "tool" }, "stone axe", "a stone axe used to chop trees");
            _items = new Item[] { _stone_Sword, _stone_Pickaxe};
            Inventory = new AddItem(_items);
        }

        [Test] // TEST 1
        public void TestUniqueItem() {
            Inventory.AddToList(_stone_Axe);
            Assert.That(Inventory.CheckInList(_stone_Axe), Is.GreaterThanOrEqualTo(1));
        }

        [Test] // TEST 2
        public void TestDuplicateItem() {
            Inventory.AddToList(_stone_Sword);
            Assert.That(Inventory.CheckInList(_stone_Sword), Is.EqualTo(1));
        }
    }
}