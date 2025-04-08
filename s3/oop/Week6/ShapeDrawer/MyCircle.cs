using SplashKitSDK;

namespace ShapeDrawer {
  public class MyCircle : Shape {
    // fields
    private int _radius;
    // defines MyCircle constructor
    public MyCircle() {
      _radius = 50;
    }

    public override void Draw() {
      if (_selected) {
        DrawOutline();
      }
      SplashKit.FillCircle(Color, X, Y, _radius);
    }

    // defines Radius property
    public int Radius {
      get {
        return _radius;
      }
      set {
        _radius = value;
      }
    }
  }
}