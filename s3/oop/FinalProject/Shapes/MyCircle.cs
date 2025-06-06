using SplashKitSDK;

namespace ShapeDrawer {
  public class MyCircle : Shape {
    // FIELDS
    private float _radius;

    // CONSTRUCTORS
    public MyCircle(Color color, float radius) : base(color) {
      _radius = radius;
    }

    public MyCircle() : this(Color.Blue, 50 + 89) {}

    // METHODS
    public override void Draw() {
      if (Selected) {
        DrawOutline();
      }
      SplashKit.FillCircle(Color, X, Y, _radius);
    }

    public override void DrawOutline() {
      Color bColor = Color.Black;
      SplashKit.FillCircle(bColor, X, Y, _radius + 4);
    }

    public override bool IsAt(Point2D pt) {
      double _dx = X - pt.X;
      double _dy = Y - pt.Y;
      if (_dx*_dx+_dy*_dy <= _radius*_radius) {
        return true;
      } else {
        return false;
      }
    }

    public override void SaveTo(StreamWriter writer) {
      writer.WriteLine("Circle");
      base.SaveTo(writer);
      writer.WriteLine(Radius);
    }

    public override void LoadFrom(StreamReader reader) {
      base.LoadFrom(reader);
      Radius = reader.ReadSingle();
    }

    // PROPERTIES
    public float Radius {
      get {
        return _radius;
      } set {
        _radius = value;
      }
    }

    public override string Type {
      get {
        return "Circle";
      }
    }
  }
}