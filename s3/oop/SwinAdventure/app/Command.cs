namespace SwinAdventure {
  public abstract class Command : IdentifiableObject {
    // Constructor
    public Command(string[] ids) : base(ids) {

    }

    // Properties
    public abstract string Execute(Player p, string[] text);
  }
}