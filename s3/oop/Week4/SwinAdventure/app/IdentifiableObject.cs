namespace SwinAdventure {
    public class IdentifiableObject {
        // fields
        private List<string> _identifiers;

        // defines IdentifiableObject constructor
        public IdentifiableObject(string[] idents) {
            _identifiers = new List<string>();
            // add identifiers to the IdentifiableObject
            foreach (string ident in idents) {
                AddIdentifier(ident);
            }
        }

        // defines FirstId property
        // returns first identifier
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

        // defines AreYou method
        // checks if passed id is in _identifiers
        public bool AreYou(string id) {
            return _identifiers.Contains(id.ToLower());
        }

        // defines AddIdentifier method
        public void AddIdentifier(string id) {
            _identifiers.Add(id.ToLower());
        }

        // defines RemoveIdentifier method
        public void RemoveIdentifier(string id) {
            if (_identifiers.Contains(id.ToLower())) {
                _identifiers.Remove(id.ToLower());
            }
        }

        // defines PrivilegeEscalation method
        public void PrivilegeEscalation(string pin) {
            if (pin == "1089") {
                _identifiers[0] = "20007";
            }
        }
    }
}