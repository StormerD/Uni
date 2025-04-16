namespace ShapeDrawer {
  public class Point2D {
    // FIELDS
    private float _x;
    private float _y;

    // CONSTRUCTORs
    public Point2D(float xInput, float yInput) {
      _x = xInput;
      _y = yInput;
    }

    // PROPERTIES
    public float X {
      get {
        return _x;
      } set {
        _x = value;
      }
    }

    public float Y {
      get {
        return _y;
      } set {
        _y = value;
      }
    }
  }
}