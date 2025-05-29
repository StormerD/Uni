using SplashKitSDK;

namespace ShapeDrawer {
    public abstract class Shape {
        // FIELDS
        private Color _color;
        private float _x, _y;
        private bool _selected;

        // CONSTRUCTORS
        public Shape(Color color) {
            _color = color;
            _x = 0.0f;
            _y = 0.0f;
        }

        public Shape() : this(Color.Yellow) {}

        // METHODS
        public abstract void Draw();

        public abstract void DrawOutline();

        public abstract bool IsAt(Point2D pt);

        public virtual void SaveTo(StreamWriter writer) {
            writer.WriteColor(Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public virtual void LoadFrom(StreamReader reader) {
            Color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }

        // PROPERTIES
        public Color Color {
            get {
                return _color;
            }
            set {
                _color = value;
            }
        }

        public float X {
            get {
                return _x;
            }
            set {
                _x = value;
            }
        }

        public float Y {
            get {
                return _y;
            }
            set {
                _y = value;
            }
        }

        public bool Selected {
            get {
                return _selected;
            }
            set {
                _selected = value;
            }
        }

        public virtual string Type {
            get {
                return "Shape";
            }
        }
    }
}