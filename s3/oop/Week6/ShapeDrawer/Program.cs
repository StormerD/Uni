using System;
using SplashKitSDK;

namespace ShapeDrawer {
    public class Program {

        private enum ShapeKind {
            Rectangle,
            Circle,
            Line
        }
        public static void Main() {

            // draw window
            Window window = new Window("Shape Drawer", 800, 600);

            // variables
            Drawing _myDrawing;
            Point2D _mousePos;
            Shape _lastShape;
            ShapeKind _kindToAdd;
            List<Shape> _shapeList;

            // setup variables
            _myDrawing = new Drawing();
            _kindToAdd = ShapeKind.Circle;
            _shapeList = new List<Shape>();
            _mousePos = new Point2D(SplashKit.MouseX(), SplashKit.MouseY());

            do {
                // clear screen
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                // update 
                _mousePos.X = SplashKit.MouseX();
                _mousePos.Y = SplashKit.MouseY();

                // event on_key_R
                if (SplashKit.KeyTyped(KeyCode.RKey)) {
                    _kindToAdd = ShapeKind.Rectangle;
                }
                
                // event on_key_C
                if (SplashKit.KeyTyped(KeyCode.CKey)) {
                    _kindToAdd = ShapeKind.Circle;
                }

                // event on_key_L
                if (SplashKit.KeyTyped(KeyCode.LKey)) {
                    _kindToAdd = ShapeKind.Line;
                }

                // event on_click__LEFT
                if (SplashKit.MouseClicked(MouseButton.LeftButton)) {
                    if (_kindToAdd == ShapeKind.Line) {
                        int i = 0;
                        int j = 0;
                        while (i < 9) {
                            Shape newLine = new MyLine();
                            float _posY = _mousePos.Y + j;
                            newLine.X = _mousePos.X;
                            newLine.Y = _posY;
                            _shapeList.Add(newLine);
                            _myDrawing.AddShape(newLine);
                            j += 10;
                            i += 1;
                            Console.WriteLine("Left MB");
                        }
                    }
                    else {
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
                        _shapeList.Add(newShape);
                        _myDrawing.AddShape(newShape);
                        Console.WriteLine("Left MB");
                    }
                }

                // event on_click_RIGHT
                if (SplashKit.MouseClicked(MouseButton.RightButton)) {
                    _myDrawing.SelectShapesAt(_mousePos);
                    Console.WriteLine("Right MB");
                }

                // event on_key_SPACE
                if (SplashKit.KeyTyped(KeyCode.SpaceKey)) {
                    _myDrawing.Background = SplashKit.RandomColor();
                    Console.WriteLine("Space Key");
                }

                // event on_key_DELETE
                if (SplashKit.KeyTyped(KeyCode.DeleteKey)) {
                    Console.WriteLine("Delete Key");
                    foreach (Shape s in _myDrawing.SelectedShapes) {
                        _shapeList.Remove(s);
                        _myDrawing.RemoveShape(s);
                    }
                }

                // event on_key_BACKSPACE
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey)) {
                    Console.WriteLine("Backspace Key");
                    _lastShape = _shapeList.Last();
                    _shapeList.Remove(_lastShape);
                    _myDrawing.RemoveShape(_lastShape);
                }

                // event on_key_L
                if (SplashKit.KeyTyped(KeyCode.LKey)) {
                    Console.WriteLine(_myDrawing.ShapeCount);
                }

                // draw _myDrawing
                _myDrawing.Draw();
                
                // refresh screen
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
