namespace SwinAdventure {
  public class MoveCommand : Command {
    // fields
    private string _direction;
    private string _errorS = "Error at move input";

    // constructor
    public MoveCommand(string[] ids) : base(ids) {

    }

    // methods
    public override string Execute(Player p, string[] text) {
      // ["move"/"go"/"head"/"leave", "north"]
      // check if length is valid
      if (text.Length == 2) {
        // check if 1st word is "move"
        if (text[0].ToLower() != "move" && text[0].ToLower() != "go" && text[0].ToLower() != "head" && text[0].ToLower() != "leave") {
          return _errorS;
        }
        // check if 2nd word is a valid direction
        if (text[1].ToLower() == "north" || text[1].ToLower() == "south" || text[1].ToLower() == "east" || text[1].ToLower() == "west") {
          _direction = text[1].ToLower();
        }
        else {
          return _errorS;
        }
      }
      else {
        return _errorS;
      }

      // handle path
      GameObject _path = p.Location.Locate(_direction);
      if (_path != null) {
        // check if path is blocked
        if (_path is Path) {
          Path path = (Path)_path;
          if (path.IsBlocked) {
            return "The path is blocked";
          }
          else {
            path.Move(p);
            return "You have moved " + path.FirstId + " through a " + path.Name + " to the " + p.Location.Name;
          }
        }
        else {
          return "You cannot move in that direction";
        }
      }
      else {
        return "There is no path in that direction";
      }
    }
  }
}