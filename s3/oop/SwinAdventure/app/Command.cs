namespace SwinAdventure {
  public abstract class Command : IdentifiableObject {
    // constructor
    public Command(string[] ids) : base(ids) {

    }

    // methods
    public abstract string Execute(Player p, string[] text);
  }
}