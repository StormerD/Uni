namespace ShapeDrawer {
  public class ScaleShapes {
    public static void ScaleAllShapes(Drawing drawing, float scaleFactor) {
      foreach (Shape s in drawing.Shapes) {
        if (s is MyRectangle r) {
          r.Width = Convert.ToSingle(r.Width * scaleFactor);
          r.Height = Convert.ToSingle(r.Height * scaleFactor);
        }
        else if (s is MyCircle c) {
          c.Radius = Convert.ToSingle(c.Radius * scaleFactor);
        }
        else if (s is MyLine l) {
          l.Length = Convert.ToSingle(l.Length * scaleFactor);
        }
      }    
    }
  }  
}