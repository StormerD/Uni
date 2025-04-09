using SplashKitSDK;

namespace ShapeDrawer {
  public class Drawing {
    // FIELDS
    private readonly List<Shape> _shapes;
    private Color _background;

    // CONSTRUCTORS
    public Drawing(Color background) {
      _shapes = new List<Shape>();
      _background = background;
    }

    public Drawing() : this(Color.White) {}

    // METHODS
    public void Draw() {
      SplashKit.ClearScreen(_background);
      foreach (Shape s in _shapes) {
        s.Draw();
      }
    }

    public void SelectShapesAt(Point2D pt) {
      foreach (Shape s in _shapes) {
        if (s.IsAt(pt)) {
          s.Selected = true;
        } else {
          s.Selected = false;
        }
      }
    }

    public void AddShape(Shape s) {
      _shapes.Add(s);
    }

    public void RemoveShape(Shape s) {
      _shapes.Remove(s);
    }

    // PROPERTIES
    public List<Shape> SelectedShapes {
      get {
        List<Shape> _result = new List<Shape>();
        foreach (Shape s in _shapes) {
          if (s.Selected) {
            _result.Add(s);
          }
        }
        return _result;
      }
    }

    public int ShapeCount {
      get {
        return _shapes.Count;
      }
    }

    public Color Background {
      get {
        return _background;
      } set {
        _background = value;
      }
    }
  }
}