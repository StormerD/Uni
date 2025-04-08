using SplashKitSDK;

namespace ShapeDrawer {
    public abstract class Shape {
        // fields
        private Color _color;
        private float _x, _y;
        private int _width, _height;
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
        public virtual void Draw() {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
            if (_selected) {
                DrawOutline();
            }
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        // defines DrawOutline method
        public virtual void DrawOutline() {
            Color bColor = Color.Black;
            float bX = _x-9;
            float bY = _y-9;
            int bWidth = _width+18;
            int bHeight = _height+18;
            SplashKit.DrawRectangle(bColor, bX, bY, bWidth, bHeight);
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