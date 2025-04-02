// Item(string[] : ids, string : name, string : description)
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
    public class Item : GameObject {
        // defines Item constructor
        public Item(string[] ids, string name, string description)
        : base(ids, name, description) {

        }
    }
}