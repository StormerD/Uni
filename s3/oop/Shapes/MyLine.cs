using SplashKitSDK;

namespace ShapeDrawer {
  public class MyLine : Shape {
    // FIELDS
    private float _length;

    // CONSTRUCTORS
    public MyLine(Color color, float x, float y, float length) : base(color) {
      X = x;
      Y = y;
      _length = length;
    }

    public MyLine() : this(Color.Red, 0.0f, 0.0f, 500) {}

    // METHODS
    public override void Draw() {
      if (Selected) {
        DrawOutline();
      }
      SplashKit.DrawLine(Color, X, Y, X + _length, Y);
    }

    public override void DrawOutline() {
      Color bColor = Color.Black;
      SplashKit.FillCircle(bColor, X, Y, 3);
      SplashKit.FillCircle(bColor, X + _length, Y, 3);
    }

    public override bool IsAt(Point2D pt) {
      if (pt.X > X && pt.X < (X + _length) && pt.Y == Y) {
        return true;
      } else {
        return false;
      }
    }

    public override void SaveTo(StreamWriter writer) {
      writer.WriteLine("Line");
      base.SaveTo(writer);
      writer.WriteLine(Length);
    }
    
    public override void LoadFrom(StreamReader reader) {
      base.LoadFrom(reader);
      Length = reader.ReadSingle();
    }

    // PROPERTIES
    public float Length {
      get {
        return _length;
      }
      set {
        _length = value;
      }
    }

    public override string Type {
      get {
        return "Line";
      }
    }
  }
}