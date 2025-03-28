using SplashKitSDK;

namespace ShapeDrawer {
    public class Shape {
        // fields
        private Color _color;
        private float _x;
        private float _xc;
        private float _y;
        private float _yc;
        private float _r;
        private int _width;
        private int _height;

        // defines Shape constructor
        public Shape(int param, float x, float y) {
            _color = Color.Azure;
            _width = param;
            _height = param;
            _x = x;
            _y = y;
            _r = _width/2;
            _xc = _x + _r;
            _yc = _y + _r;
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

        // defines DrawRectangle method
        public void DrawRectangle() {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        // defines DrawEllipse method
        public void DrawEllipse() {
            SplashKit.FillEllipse(_color, _x, _y, _width, _height);
        }

        // defines InEllipse method
        public bool InEllipse(float mx, float my) {
            float dx = _xc - mx;
            float dy = _yc - my;
            return dx * dx + dy * dy <= (_r+25) * (_r+25);
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