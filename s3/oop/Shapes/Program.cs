// - - - - - - - - - - - - - - - - -
// By Dylan Rodwell
// 105341089
// - - - - - - - - - - - - - - - - -

using SplashKitSDK;

namespace ShapeDrawer {
  public class Program {
    private enum ShapeKind {
      Rectangle,
      Circle,
      Line,
      MLine,
    }

    public static void Main() {
      // INIT WINDOW
      int winWidth = 800;
      int winHeight = 600;
      Window window = new Window("Shape Drawer", winWidth, winHeight);

      // VARIABLES
      Drawing _myDrawing;
      ShapeKind _kindToAdd;
      Point2D _mousePos;

      // SETUP VARIABLES
      _myDrawing = new Drawing();
      _kindToAdd = ShapeKind.Circle;
      _mousePos = new Point2D(SplashKit.MouseX(), SplashKit.MouseY());

      do {
        // CLEAR SCREEN
        SplashKit.ProcessEvents();
        SplashKit.ClearScreen();
        
        // UPDATE MOUSE POSITION
        _mousePos.X = SplashKit.MouseX();
        _mousePos.Y = SplashKit.MouseY();

        // Key R -- Select Rectangle
        if (SplashKit.KeyTyped(KeyCode.RKey)) {
          _kindToAdd = ShapeKind.Rectangle;
          Console.WriteLine("Rectangle Selected!");
        }

        // Key C -- Select Circle
        if (SplashKit.KeyTyped(KeyCode.CKey)) {
          _kindToAdd = ShapeKind.Circle;
          Console.WriteLine("Circle Selected!");
        }

        // Key K -- Select Line
        if (SplashKit.KeyTyped(KeyCode.KKey)) {
          _kindToAdd = ShapeKind.Line;
          Console.WriteLine("Line Selected!");
        }

        // Key L -- Select Multiple Lines
        if (SplashKit.KeyTyped(KeyCode.LKey)) {
          _kindToAdd = ShapeKind.MLine;
          Console.WriteLine("Multiple Lines Selected!");
        }

        // Key LMB -- Add Shape
        if (SplashKit.MouseClicked(MouseButton.LeftButton)) {
          if (_kindToAdd == ShapeKind.MLine) {
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
          }
          else {
            Shape newShape;
            switch (_kindToAdd) {
              case ShapeKind.Circle:
                newShape = new MyCircle();
                break;
              case ShapeKind.Line:
                newShape = new MyLine();
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

        // Key RMB -- Select Shapes
        if (SplashKit.MouseClicked(MouseButton.RightButton)) {
          _myDrawing.SelectShapesAt(_mousePos);
        }

        // Key SPACE -- New Background
        if (SplashKit.KeyTyped(KeyCode.SpaceKey)) {
          _myDrawing.Background = SplashKit.RandomColor();
          Console.WriteLine("New Background!");
        }

        // Key BACKSPACE -- Delete Last Shape
        if (SplashKit.KeyTyped(KeyCode.BackspaceKey)) {
          if (_myDrawing.LastShape != null) {
            Console.WriteLine("Deleting Shape: " + _myDrawing.LastShape.Type);
            _myDrawing.RemoveShape(_myDrawing.LastShape);
          }
          else {
            Console.WriteLine("No shape to delete");
          }
        }

        // Key DELETE -- Delete Selected Shapes
        if (SplashKit.KeyTyped(KeyCode.DeleteKey)) {
          foreach (Shape s in _myDrawing.SelectedShapes) {
            _myDrawing.RemoveShape(s);
          }
        }

        // Key A -- Color All Shapes
        if (SplashKit.KeyTyped(KeyCode.AKey)) {
          foreach (Shape s in _myDrawing.Shapes) {
            Color randomColor = SplashKit.RandomRGBColor(255);
            s.Color = randomColor;
          }
          Console.WriteLine("All Shapes Colored!");
        }

        // Key N -- Draw Name
        if (SplashKit.KeyTyped(KeyCode.NKey)) {
          Random rand = new Random();
          float baseX = rand.Next(50, winWidth - 100); // X border
          float baseY = rand.Next(50, winHeight - 150); // Y border
          Color baseColor = Color.RGBAColor(0, 0, 0, 255); // Color black
          
          NameDrawer.DrawName(_myDrawing, baseX, baseY, baseColor);
        }

        // Key D -- Draw Random Shapes
        if (SplashKit.KeyTyped(KeyCode.DKey)) {
          RandomShapeDrawer.AddRandomShapes(_myDrawing, winWidth, winHeight);
        }

        // Key M -- Scale Shapes
        if (SplashKit.KeyTyped(KeyCode.MKey)) {
          ScaleShapes.ScaleAllShapes(_myDrawing, 0.8f);
        }

        // Key S -- Save Drawing
        if (SplashKit.KeyTyped(KeyCode.SKey)) {
          _myDrawing.Save("TestDrawing.txt");
          Console.WriteLine("Drawing Saved!");
        }

        // Key O -- Load Drawing
        if (SplashKit.KeyTyped(KeyCode.OKey)) {
          try {
          _myDrawing.Load("TestDrawing.txt");
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