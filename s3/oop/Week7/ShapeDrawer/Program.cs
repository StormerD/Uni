using SplashKitSDK;

namespace ShapeDrawer {
  public class Program {
    private enum ShapeKind {
      Rectangle,
      Circle,
      Line
    }

    public static void Main() {
      // INIT WINDOW
      Window window = new Window("Shape Drawer", 800, 600);

      // VARIABLES
      Drawing _myDrawing;
      Point2D _mousePos;
      ShapeKind _kindToAdd;

      // SETUP VARIABLES
      _myDrawing = new Drawing();
      _kindToAdd = ShapeKind.Circle;
      _mousePos = new Point2D(SplashKit.MouseX(), SplashKit.MouseY());

      do {
        // CLEAR SCREEN
        SplashKit.ProcessEvents();
        SplashKit.ClearScreen();

        // UPDATE
        _mousePos.X = SplashKit.MouseX();
        _mousePos.Y = SplashKit.MouseY();

        // EVENT on_key_R
        if (SplashKit.KeyTyped(KeyCode.RKey)) {
          _kindToAdd = ShapeKind.Rectangle;
          Console.WriteLine("Rectangle Selected!");
        }

        // EVENT on_key_C
        if (SplashKit.KeyTyped(KeyCode.CKey)) {
          _kindToAdd = ShapeKind.Circle;
          Console.WriteLine("Circle Selected!");
        }

        // EVENT on_key_L
        if (SplashKit.KeyTyped(KeyCode.LKey)) {
          _kindToAdd = ShapeKind.Line;
          Console.WriteLine("Line Selected!");
        }

        // EVENT on_click_LEFT
        if (SplashKit.MouseClicked(MouseButton.LeftButton)) {
          if (_kindToAdd == ShapeKind.Line) {
            int i = 0;
            int j = 0;
            while (i < 9) {
              Shape newLine = new MyLine();
              float _posY = _mousePos.Y + j;
              newLine.X = _mousePos.X;
              newLine.Y = _posY;
              _myDrawing.AddShape(newLine);
              j += 10;
              i += 1;
            }
          } else {
            Shape newShape;
            switch (_kindToAdd) {
              case ShapeKind.Circle:
                newShape = new MyCircle();
                break;
              default:
                newShape = new MyRectangle();
                break;
            }
            newShape.X = _mousePos.X;
            newShape.Y = _mousePos.Y;
            _myDrawing.AddShape(newShape);
          }
        }

        // EVENT on_click_RIGHT
        if (SplashKit.MouseClicked(MouseButton.RightButton)) {
          _myDrawing.SelectShapesAt(_mousePos);
        }

        // EVENT on_key_SPACE
        if (SplashKit.KeyTyped(KeyCode.SpaceKey)) {
          _myDrawing.Background = SplashKit.RandomColor();
          Console.WriteLine("New Background!");
        }

        // EVENT on_key_DELETE
        if (SplashKit.KeyTyped(KeyCode.DeleteKey)) {
          foreach (Shape s in _myDrawing.SelectedShapes) {
            _myDrawing.RemoveShape(s);
          }
        }

        // EVENT on_key_BACKSPACE
        if (SplashKit.KeyTyped(KeyCode.BackspaceKey)) {
          if (_myDrawing.LastShape != null) {
            Console.WriteLine("Deleting Shape: " + _myDrawing.LastShape.Type);
            _myDrawing.RemoveShape(_myDrawing.LastShape);
          }
          else {
            Console.WriteLine("No shape to delete");
          }
        }

        // EVENT on_key_S
        if (SplashKit.KeyTyped(KeyCode.SKey)) {
          _myDrawing.Save("/Users/drodw/Desktop/TestDrawing.txt");
          Console.WriteLine("Drawing Saved!");
        }

        // // EVENT on_key_O
        if (SplashKit.KeyTyped(KeyCode.OKey)) {
          try {
          _myDrawing.Load("/Users/drodw/Desktop/TestDrawing.txt");
          Console.WriteLine("Drawing Loaded!");
          }
          catch (Exception e) {
            Console.Error.WriteLine("Error loading file {0}: " + e.Message);
          }
        }

        // DRAW
        _myDrawing.Draw();

        // REFRESH SCREEN
        SplashKit.RefreshScreen();
      } while (!window.CloseRequested);
    }
  }
}