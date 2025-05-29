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
      int winWidth = 800;
      int winHeight = 600;
      Window window = new Window("Shape Drawer", winWidth, winHeight);

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

        // EVENT on_key_D
        if (SplashKit.KeyTyped(KeyCode.DKey)) {
          Random rand = new Random();
          int shapeCount = rand.Next(1, 5); // Draw between 1 and 5 shapes
          for (int i = 0; i < shapeCount; i++) {
            Color randomColor = SplashKit.RandomRGBColor(255);
            Shape shape;
            int shapeType = rand.Next(0, 3); // 0 for Rectangle, 1 for Circle, 2 for Line
            float x = rand.Next(0, winWidth);
            float y = rand.Next(0, winHeight);

            switch (shapeType) {
              case 0:
                shape = new MyRectangle();
                break;
              case 1:
                shape = new MyCircle();
                break;
              default:
                shape = new MyLine();
                break;
            }
            shape.X = x;
            shape.Y = y;
            shape.Color = randomColor;
            _myDrawing.AddShape(shape);
          }
          Console.WriteLine(shapeCount + " Random Shapes Added!");
        }

        // Event on_key_N
        if (SplashKit.KeyTyped(KeyCode.NKey))
        {
          Random rand = new Random();
          float baseX = rand.Next(50, winWidth - 100);
          float baseY = rand.Next(50, winHeight - 150);
          Color baseColor = Color.RGBAColor(0, 0, 0, 255); // Semi-transparent red

          // -- DRAW D --

          // Vertical line (as a rectangle)
          MyRectangle left = new MyRectangle();
          left.X = baseX;
          left.Y = baseY;
          left.Width = 20;
          left.Height = 60;
          left.Color = baseColor;
          _myDrawing.AddShape(left);

          // Top curve (as a circle)
          MyCircle Dtop = new MyCircle();
          Dtop.X = baseX + 20;
          Dtop.Y = baseY + 20;
          Dtop.Radius = 20;
          Dtop.Color = baseColor;
          _myDrawing.AddShape(Dtop);

          // Bottom curve (as a circle)
          MyCircle Dbottom = new MyCircle();
          Dbottom.X = baseX + 20;
          Dbottom.Y = baseY + 39;
          Dbottom.Radius = 20;
          Dbottom.Color = baseColor;
          _myDrawing.AddShape(Dbottom);

          // Middle curve (as a circle)
          MyCircle Dmiddle = new MyCircle();
          Dmiddle.X = baseX + 23;
          Dmiddle.Y = baseY + 30;
          Dmiddle.Radius = 20;
          Dmiddle.Color = baseColor;
          _myDrawing.AddShape(Dmiddle);

          // -- DRAW Y --
          baseX += 50; // Move baseX for the next shape

          // Left vertical line (as a rectangle)
          MyRectangle Yleft = new MyRectangle();
          Yleft.X = baseX;
          Yleft.Y = baseY + 20;
          Yleft.Width = 5;
          Yleft.Height = 15;
          Yleft.Color = baseColor;
          _myDrawing.AddShape(Yleft);

          // Top horizontal line (as a rectangle)
          MyRectangle Ytop = new MyRectangle();
          Ytop.X = baseX + 5;
          Ytop.Y = baseY + 35;
          Ytop.Width = 20;
          Ytop.Height = 5;
          Ytop.Color = baseColor;
          _myDrawing.AddShape(Ytop);

          // Right vertical line (as a rectangle)
          MyRectangle Yright = new MyRectangle();
          Yright.X = baseX + 25;
          Yright.Y = baseY + 20;
          Yright.Width = 5;
          Yright.Height = 45;
          Yright.Color = baseColor;
          _myDrawing.AddShape(Yright);

          // Bottom diagonal line (as a rectangle)
          MyRectangle Ybottom = new MyRectangle();
          Ybottom.X = baseX + 5;
          Ybottom.Y = baseY + 65;
          Ybottom.Width = 20;
          Ybottom.Height = 5;
          Ybottom.Color = baseColor;
          _myDrawing.AddShape(Ybottom);

          // -- DRAW L --
          baseX += 40; // Move baseX for the next shape

          // Vertical line (as a rectangle)
          MyRectangle Lleft = new MyRectangle();
          Lleft.X = baseX;
          Lleft.Y = baseY;
          Lleft.Width = 5;
          Lleft.Height = 60;
          Lleft.Color = baseColor;
          _myDrawing.AddShape(Lleft);

          // -- DRAW A --
          baseX += 20; // Move baseX for the next shape

          // Left vertical line (as a rectangle)
          MyRectangle Aleft = new MyRectangle();
          Aleft.X = baseX;
          Aleft.Y = baseY + 25;
          Aleft.Width = 5;
          Aleft.Height = 35;
          Aleft.Color = baseColor;
          _myDrawing.AddShape(Aleft);

          // Top horizontal line (as a rectangle)
          MyRectangle Atop = new MyRectangle();
          Atop.X = baseX + 5;
          Atop.Y = baseY + 20;
          Atop.Width = 20;
          Atop.Height = 5;
          Atop.Color = baseColor;
          _myDrawing.AddShape(Atop);

          // Right vertical line (as a rectangle)
          MyRectangle Aright = new MyRectangle();
          Aright.X = baseX + 25;
          Aright.Y = baseY + 25;
          Aright.Width = 5;
          Aright.Height = 35;
          Aright.Color = baseColor;
          _myDrawing.AddShape(Aright);

          // Middle horizontal line (as a rectangle)
          MyRectangle Amiddle = new MyRectangle();
          Amiddle.X = baseX + 5;
          Amiddle.Y = baseY + 40;
          Amiddle.Width = 20;
          Amiddle.Height = 5;
          Amiddle.Color = baseColor;
          _myDrawing.AddShape(Amiddle);

          // -- DRAW N --
          baseX += 40; // Move baseX for the next shape

          // Left vertical line (as a rectangle)
          MyRectangle Nleft = new MyRectangle();
          Nleft.X = baseX;
          Nleft.Y = baseY + 30;
          Nleft.Width = 5;
          Nleft.Height = 30;
          Nleft.Color = baseColor;
          _myDrawing.AddShape(Nleft);

          // Top horizontal line (as a rectangle)
          MyRectangle Ntop = new MyRectangle();
          Ntop.X = baseX + 5;
          Ntop.Y = baseY + 25;
          Ntop.Width = 20;
          Ntop.Height = 5;
          Ntop.Color = baseColor;
          _myDrawing.AddShape(Ntop);

          // Right vertical line (as a rectangle)
          MyRectangle Nright = new MyRectangle();
          Nright.X = baseX + 25;
          Nright.Y = baseY + 30;
          Nright.Width = 5;
          Nright.Height = 30;
          Nright.Color = baseColor;
          _myDrawing.AddShape(Nright);

        }

        // EVENT on_key_A
        if (SplashKit.KeyTyped(KeyCode.AKey)) {
          foreach (Shape s in _myDrawing.Shapes) {
            Color randomColor = SplashKit.RandomRGBColor(255);
            s.Color = randomColor;
          }
          Console.WriteLine("Selected Shapes Colored!");
        }

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