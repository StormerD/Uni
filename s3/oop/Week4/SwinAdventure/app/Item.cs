namespace SwinAdventure {
// Item(string[]: identifiers, string: name, string: description)
// Item.AreYou(string: id): bool
// Item.AddIdentifier(string: id)
// Item.RemoveIdentifier(string: id)
// Item.PrivilegeEscalation(string: pin)
// Item.Name
// Item.ShortDescription
// Item.Description
// Item.FirstId
    public class Item {
        // fields
        private List<string> _identifiers;
        private string _description;
        private string _name;

        // defines Item constructor
        public Item(string[] idents, string name, string desc) {
            _identifiers = new List<string>();
            // add identifiers to Item object
            foreach (string ident in idents) {
                AddIdentifier(ident);
            }
            _name = name;
            _description = desc;
        }

        // defines AreYou method
        public bool AreYou(string id) {
            return _identifiers.Contains(id.ToLower());
        }

        // defines AddIdentifier method
        public void AddIdentifier(string id) {
            _identifiers.Add(id.ToLower());
        }

        // defines RemoveIdentifier method
        public void RemoveIdentifier(string id) {
            _identifiers.Remove(id.ToLower());
        }

        // defines PrivilegeEscalation method
        public void PrivilegeEscalation(string pin) {
            if (pin == "1089") {
                _identifiers[0] = "20007";
            }
        }

        // defines Name property
        public string Name {
            get {
                return _name;
            }
        }

        // defines  ShortDescription property
        public string ShortDescription {
            get {
                return "a " + _name + " (" + FirstId + ")";
            }
        }

        // defines Description property
        public string Description {
            get {
                return _description;
            }
        }

        // defines FirstId property
        public string FirstId {
            get {
                if (_identifiers.Count == 0) {
                    return "";
                }
                else {
                    return _identifiers.First();
                }
            }
        }
    }
}