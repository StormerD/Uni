namespace ShapeDrawer {
    public class Point2D {
        // fields
        private float _x;
        private float _y;

        // defines Point2D constructor
        public Point2D(float xInput, float yInput) {
            _x = xInput;
            _y = yInput;
        }

        // defines X property
        public float X {
            get {
                return _x;
            }
            set {
                _x = value;
            }
        }

        // defines Y property
        public float Y {
            get {
                return _y;
            }
            set {
                _y = value;
            }
        }
    }
}