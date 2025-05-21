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

        // constructors
        public GameObject(string[] ids, string name, string description) : base(ids) {
            _name = name;
            _description = description;
        }

        // methods
        public virtual void SaveTo(StreamWriter writer) {
            // save the GameObject's name and description to file
            writer.WriteLine(_name);
            writer.WriteLine(_description);
        }

        public virtual void LoadFrom(StreamReader reader) {
            // read the GameObject's name and description from file
            _name = reader.ReadLine();
            _description = reader.ReadLine();
        }

        // properties
        public string Name {
            get {
                return _name;
            }
        }

        public virtual string ShortDescription {
            get {
                return _name + " (" + FirstId + ")";
            }
        }

        public virtual string FullDescription {
            get {
                return _description;
            }
        }
    }
}