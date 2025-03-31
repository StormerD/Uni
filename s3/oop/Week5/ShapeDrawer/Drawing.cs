using SplashKitSDK;
// 
namespace ShapeDrawer {
    public class Drawing {
        // fields
        private readonly List<Shape> _shapes;
        private Color _background;

        // defines Drawing constructor
        public Drawing(Color background) {
            _shapes = new List<Shape>();
            _background = background;
        }

        // defines default constructor
        public Drawing() : this(Color.White) {

        }

        // defines Draw method
        public void Draw() {
            SplashKit.ClearScreen(_background);

            foreach (Shape s in _shapes) {
                s.Draw();
            }
        }

        // defines SelectShapesAt method
        public void SelectShapesAt(Point2D pt) {
            foreach (Shape s in _shapes) {
                if (s.IsAt(pt)) {
                    s.Selected = true;
                } else {
                    s.Selected = false;
                }
            }
        }

        // defines AddShape method
        public void AddShape(Shape s) {
            _shapes.Add(s);
        }

        // defines RemoveShape method
        public void RemoveShape(Shape s) {
            _shapes.Remove(s);
        }

        // defines SelectedShapes property
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

        // defines ShapeCount property
        public int ShapeCount {
            get {
                return _shapes.Count;
            }
        }

        // defines Background property
        public Color Background {
            get {
                return _background;
            }
            set {
                _background = value;
            }
        }
    }
}