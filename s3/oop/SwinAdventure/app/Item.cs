// Item(string[]: identifiers, string: name, string: description)
// AreYou(string: id): bool
// AddIdentifier(string: id)
// RemoveIdentifier(string: id)
// PrivilegeEscalation(string: pin)
// FirstId: string
// Name: string
// ShortDescription: string
// FullDescription: string
namespace SwinAdventure {
    public class Item : GameObject {
        // defines Item constructor
        public Item(string[] idents, string name, string description)
        : base(idents, name, description) {

        }
    }
}