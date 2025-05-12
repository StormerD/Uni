namespace SwinAdventure {
  public class LookCommand : Command {
    // constructor
    public LookCommand(string[] ids) : base(ids) {

    }

    // methods
    public override string Execute(Player p, string[] text) {
      if (text.Length == 3 || text.Length == 5) {
        if (text[0].ToLower() != "look") {
          return "Error in look input";
        }
        if (text[1].ToLower() != "at") {
          return "What do you want to look at?";
        }
        if (text.Length == 3) {
          IHaveInventory container = p;
          return LookAtIn(text[2], container);
        }
        if (text.Length == 5) {
          if (text[3].ToLower() != "in") {
            return "What do you want to look in?";
          }
          IHaveInventory fetchContainer = FetchContainer(p, text[4]);
          if (fetchContainer != null) {
            return LookAtIn(text[2], fetchContainer);
          } else {
            return "I can't find the " + text[4];
          }
        }
      }
      return "I don't know how to look like that";
    }

    private IHaveInventory FetchContainer(Player p, string containerId) {
      if (p.AreYou(containerId)) {
        return p;
      } else {
        return (IHaveInventory)p.Locate(containerId);
      }
    }

    private string LookAtIn(string thingId, IHaveInventory container) {
      GameObject itm = container.Locate(thingId);
      if (itm == null) {
        return "I can't find the " + thingId;
      }
      return itm.FullDescription;
    }
  }
}