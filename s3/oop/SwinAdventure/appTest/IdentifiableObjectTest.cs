using Newtonsoft.Json.Bson;
using NUnit.Framework.Legacy;
namespace SwinAdventure {
    public class IdentifiableObjectTest {

        // TEST 1
        private string _test1String;
        private string[] _test1Array;
        private IdentifiableObject _test1Object;
        // TEST 2
        private string _test2String;
        private string[] _test2Array;
        private IdentifiableObject _test2Object;
        // TEST 3
        private string _test3String;
        private string[] _test3Array;
        private IdentifiableObject _test3Object;
        // TEST 4
        private string _test4String;
        private string[] _test4Array;
        private IdentifiableObject _test4Object;
        // TEST 5
        private string _test5String;
        private string[] _test5Array;
        private IdentifiableObject _test5Object;
        // TEST 6
        private string _test6String;
        private string[] _test6Array;
        private IdentifiableObject _test6Object;
        // TEST 7
        private string _test7String;
        private string[] _test7Array;
        private IdentifiableObject _test7Object;

        [SetUp]
        public void Setup() {
            // TEST 1
            _test1String = "105341089";
            _test1Array = new string[] { "105341089", "Dylan", "Rodwell" };
            _test1Object = new IdentifiableObject(_test1Array);
            // TEST 2
            _test2String = "1O5341o89";
            _test2Array = new string[] { "105341089", "Dylan", "Rodwell" };
            _test2Object = new IdentifiableObject(_test2Array);
            // TEST 3
            _test3String = "DYLAN";
            _test3Array = new string[] { "105341089", "Dylan", "Rodwell" };
            _test3Object = new IdentifiableObject(_test3Array);
            // TEST 4
            _test4String = "105341089";
            _test4Array = new string[] { "105341089", "Dylan", "Rodwell" };
            _test4Object = new IdentifiableObject(_test4Array);
            // TEST 5
            _test5String = "";
            _test5Array = new string[] {};
            _test5Object = new IdentifiableObject(_test5Array);
            // TEST 6
            _test6String = "Tom";
            _test6Array = new string[] { "Dylan", "Jack", "Leo" };
            _test6Object = new IdentifiableObject(_test6Array);
            // TEST 7
            _test7String = "20007";
            _test7Array = new string[] { "Dylan", "Jack", "Leo" };
            _test7Object = new IdentifiableObject(_test7Array);
        }

        [Test] // TEST 1: pass if _test1String is found in the object identifiers
        public void TestAreYou() {
            ClassicAssert.True(_test1Object.AreYou(_test1String));
        }

        [Test] // TEST 2: pass if _test2String is not found in the object identifiers
        public void TestNotAreYou() {
            ClassicAssert.False(_test2Object.AreYou(_test2String));
        }

        [Test] // TEST 3: pass if _test3String is found in the object identifiers
        public void TestCaseSensitive() {
            ClassicAssert.True(_test3Object.AreYou(_test3String));
        }

        [Test] // TEST 4: pass if FirstId returns the first identifier in the list
        public void TestFirstId() {
            Assert.That(_test4String, Is.EqualTo(_test4Object.FirstId));
        }

        [Test] // TEST 5: pass if empty string is returned when there are no identifiers in list
        public void TestFirstIdWithNoIds() {
            Assert.That(_test5String, Is.EqualTo(_test5Object.FirstId));
        }

        [Test] // TEST 6: pass if can add identifier to object list
        public void TestAddId() {
            ClassicAssert.False(_test6Object.AreYou(_test6String));
            _test6Object.AddIdentifier(_test6String);
            ClassicAssert.True(_test6Object.AreYou(_test6String));
        }

        [Test] // TEST 7: pass if first id is course id
        public void TestPrivilegeEscalation() {
            ClassicAssert.False(_test7Object.AreYou(_test7String));
            _test7Object.PrivilegeEscalation("1089");
            ClassicAssert.True(_test7Object.AreYou(_test7String));
            
        }
    }
}