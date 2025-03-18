using System;
namespace ShapeDrawing {
    public class Shape {
        // fields
        private string _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;

        // defines Shape constructor
        public Shape(int param) {
            _color = "Color.Azure";
            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
        }

        // defines Color property
        public string Color {
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
            Console.WriteLine("Color is " + _color);
            Console.WriteLine("Position X is " + _x);
            Console.WriteLine("Position Y is " + _y);
            Console.WriteLine("Width is " + _width);
            Console.WriteLine("Height is " + _height);
        }

        // defines IsAt method
        public bool IsAt(int xInput, int yInput) {
            if (xInput > _x && yInput > _y && xInput < _width && yInput < _height) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}