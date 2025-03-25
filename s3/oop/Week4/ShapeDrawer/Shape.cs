using SplashKitSDK;

namespace ShapeDrawer {
    public class Shape {
        // fields
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;

        // defines Shape constructor
        public Shape(int param) {
            _color = Color.Azure;
            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
        }

        // defines Color property
        public Color Color {
            get {
                return _color;
            }
            set {
                _color = value;
            }
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

        // defines Width property
        public int Width {
            get {
                return _width;
            }
            set {
                _width = value;
            }
        }

        // defines Height property
        public int Height {
            get {
                return _height;
            }
            set {
                _height = value;
            }
        }

        // defines Draw method
        public void Draw() {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        // defines IsAt method
        public bool IsAt(Point2D pt) {
            if(pt.X > _x && pt.Y > _y && pt.X < (_x+_width) && pt.Y < (_y+_height)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}