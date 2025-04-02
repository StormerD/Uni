// GameObject(string[] : ids, string : name, string : description)
// AreYou(string : id) : bool
// AddIdentifier(string : id) : void
// RemoveIdentifier(string : id) : void
// PrivilegeEscalation(string : pin) : void
// FirstId : string
// IdCount : int
// Name : string
// ShortDescription : string
// FullDescription : string
namespace SwinAdventure {
    public class GameObject : IdentifiableObject {
        // fields
        private string _name, _description;

        // defines GameObject constructor
        public GameObject(string[] ids, string name, string description) : base(ids) {
            _name = name;
            _description = description;
        }

        // defines Name property
        public string Name {
            get {
                return _name;
            }
        }

        // defines ShortDescription property
        public string ShortDescription {
            get {
                return "a " + _name + " (" + FirstId + ")";
            }
        }

        // defines FullDescription property
        public virtual string FullDescription {
            get {
                return _description;
            }
        }
    }
}