using SplashKitSDK;

namespace ShapeDrawer {
  public class Drawing {
    // FIELDS
    private readonly List<Shape> _shapes;
    private Color _background;

    StreamReader reader;
    StreamWriter writer;

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

    public void Save(string filename) {
      writer = new StreamWriter(filename);

      try {
        writer.WriteColor(_background);
        writer.WriteLine(ShapeCount);

        foreach (Shape s in _shapes) {
          s.SaveTo(writer);
        }
      }
      finally {
        writer.Close();
      }
    }

    public void Load(string filename) {
      reader = new StreamReader(filename);
      try {
        int count;
        Shape s;
        string kind;
        int j = 0;
      
        Background = reader.ReadColor();
        count = reader.ReadInteger();
        _shapes.Clear();

        for (int i = 0; i < count; i++) {
          kind = reader.ReadLine();
          switch (kind) {
            case "Rectangle":
              s = new MyRectangle();
              break;
            case "Circle":
              s = new MyCircle();
              break;
            case "Line":
              s = new MyLine();
              break;
            default:
              throw new InvalidDataException("Error at shape: " + kind);
          }
          s.LoadFrom(reader);
          AddShape(s);
          Console.WriteLine("Drawing Shape " + j.ToString() + ": " + kind);
          j++;
        }
      }
      finally {
        reader.Close();
      }
    }

    // PROPERTIES
    public List<Shape> Shapes {
      get {
        return _shapes;
      }
    }
    
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

    public Shape? LastShape {
      get {
        try {
          return _shapes.Last();
        }
        catch (Exception e) {
          Console.Error.WriteLine("Error: no shapes in list {0}" + e.Message);
          return null;
        }
      }
    }
  }
}