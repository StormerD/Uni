using SplashKitSDK;

namespace ShapeDrawer {
  public class MyRectangle : Shape {
    // FIELDS
    private float _width, _height;

    // CONSTRUCTORS
    public MyRectangle(Color color, float x, float y, float width, float height) : base(color) {
      X = x;
      Y = y;
      _width = 100;
      _height = 100;
    }

    public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 198, 189) {}

    // METHODS
    public override void Draw() {
      if (Selected) {
        DrawOutline();
      }
      SplashKit.FillRectangle(Color, X, Y, _width, _height);
    }

    public override void DrawOutline() {
      Color bColor = Color.Black;
      float bX = X - 4;
      float bY = Y - 4;
      float bWidth = Width + 8;
      float bHeight = Height + 8;
      SplashKit.FillRectangle(bColor, bX, bY, bWidth, bHeight);
    }

    public override bool IsAt(Point2D pt) {
      if (pt.X > X && pt.Y > Y && pt.X < (X+_width) && pt.Y < (Y+_height)) {
        return true;
      } else {
        return false;
      }
    }

    public override void SaveTo(StreamWriter writer) {
      writer.WriteLine("Rectangle");
      base.SaveTo(writer);
      writer.WriteLine(Width);
      writer.WriteLine(Height);
    }

    public override void LoadFrom(StreamReader reader) {
      base.LoadFrom(reader);
      Width = reader.ReadSingle();
      Height = reader.ReadSingle();
    }

    // PROPERTIES
    public float Width {
      get {
        return _width;
      } set {
        _width = value;
      }
    }

    public float Height {
      get {
        return _height;
      } set {
        _height = value;
      }
    }

    public override string Type {
      get {
        return "Rectangle";
      }
    }
  }
}