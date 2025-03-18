using System;

namespace SwinAdventure {
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

        // defines Name property
        public string Name {
            get {
                return _name;
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

        // defines  ShortDescription property
        public string ShortDescription {
            get {
                return ()
            }
        }

        // defines AreYou method
    }
}