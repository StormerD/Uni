namespace SwinAdventure {
  public class Path : GameObject {
    // Path({"direction"}, ")

    // fields
    bool _isBlocked;

    Location _origin, _destination;

    // constructor
    public Path(string[] ids, string name, string desc, Location origin, Location destination, bool isBlocked) : base(ids, name, desc) {
      _origin = origin;
      _destination = destination;
      _isBlocked = isBlocked;
    }

    // methods
    public void Move(Player player) {
      if (_destination != null) {
        player.Location = _destination;
      }
    }

    // properties
    public Location Destination {
      get {
        return _destination;
      }
    }

    public override string ShortDescription {
      get {
        return Name;
      }
    }

    public bool IsBlocked {
      get {
        return _isBlocked;
      }
      set {
        _isBlocked = value;
      }
    }
  }
}