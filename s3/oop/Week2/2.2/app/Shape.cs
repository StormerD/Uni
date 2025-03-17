using System;
using SplashKitSDK;
namespace ShapeTask {
    public class Shape {
        private string _color;
        private float _x, _y;
        private int _weight, _height;

        // defines Shape constructor
        public Shape(int Param) {

        }

        // defines Draw method
        public void Draw() {
            Console.WriteLine("Color is " + _color);
            Console.WriteLine("Position X is " + _x);
            Console.WriteLine("Position Y is " + _y);
            Console.WriteLine("Weight is " + _weight);
            Console.WriteLine("Height is " + _height);
        }

        // defines IsAt method
        public void IsAt(int xInput, int yInput) {
            if (xInput == _x && yInput == _y) {
                return true;
            }
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
        public string X {
            get {
                return _x;
            }
            set {
                _x = value;
            }
        }

        // defines Y property
        public string Y {
            get {
                return _y;
            }
            set {
                _y = value;
            }
        }

        // defines Weight property
        public string Weight {
            get {
                return _weight;
            }
            set {
                _weight = value;
            }
        }

        // defines Height property
        public string Height {
            get {
                return _height;
            }
            set {
                _height = value;
            }
        }

    }
}