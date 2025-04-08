using SplashKitSDK;

namespace ShapeDrawer {
    public abstract class Shape {
        // fields
        private Color _color;
        private float _x, _y;
        private bool _selected;

        // defines Shape constructor
        public Shape() {
            _color = Color.Azure;
            _width = 100;
            _height = 100;
            _x = 0;
            _y = 0;
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

        // defines Selected property
        public bool Selected {
            get {
                return _selected;
            }
            set {
                _selected = value;
            }
        }

        // defines DrawRectangle method
        public void Draw() {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
            if (_selected) {
                DrawOutline();
            }
        }

        // defines DrawOutline method
        public void DrawOutline() {
            Color rColor = Color.Black;
            float rX = _x-9;
            float rY = _y-9;
            int rWidth = _width+18;
            int rHeight = _height+18;
            SplashKit.DrawRectangle(rColor, rX, rY, rWidth, rHeight);
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