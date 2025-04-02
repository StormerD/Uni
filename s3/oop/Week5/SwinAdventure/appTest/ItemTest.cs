namespace SwinAdventure {
    public class ItemTest {
        // TEST variables
        private string _test1String = "sword";
        private Item _bronze_Sword;

        [SetUp]
        public void Setup() {
            // TEST Setup
            _bronze_Sword = new Item(new string[] { "sword", "bronze", "weapon",}, "bronze sword", "a sharp bronze sword used to slay monsters");
        }

        [Test] // TEST 1: pass if item is identifiable
        public void TestItemIsIdentifiable() {
            Assert.That(_bronze_Sword.AreYou(_test1String), Is.True);
        }

        [Test] // TEST 2: pass if returns full short description
        public void TestShortDescription() {
            Assert.That(_bronze_Sword.ShortDescription, Is.EqualTo("a bronze sword (sword)"));
        }

        [Test] // TEST 3: pass if returns full description
        public void TestFullDescription() {
            Assert.That(_bronze_Sword.FullDescription, Is.EqualTo("a sharp bronze sword used to slay monsters"));
        }

        [Test] // TEST 4: pass if first id is course id
        public void TestPrivilegeEscalation() {
            _bronze_Sword.PrivilegeEscalation("1089");
            Assert.That(_bronze_Sword.FirstId, Is.EqualTo("20007"));            
        }
    }
}