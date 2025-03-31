using System;
using SplashKitSDK;

namespace ShapeDrawer {
    public class Program {
        public static void Main() {

            // draw window
            Window window = new Window("Shape Drawer", 800, 600);

            // variables
            Drawing myDrawing;
            Point2D mousePos;

            // setup variables
            myDrawing = new Drawing();
            mousePos = new Point2D(SplashKit.MouseX(), SplashKit.MouseY());

            do {
                // clear screen
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                // update 
                mousePos.X = SplashKit.MouseX();
                mousePos.Y = SplashKit.MouseY();

                // event on_click__LEFT
                if (SplashKit.MouseClicked(MouseButton.LeftButton)) {
                    Shape newShape = new Shape();
                    newShape.X = mousePos.X;
                    newShape.Y = mousePos.Y;
                    myDrawing.AddShape(newShape);
                    Console.WriteLine("Left MB");
                }

                // event on_click_RIGHT
                if (SplashKit.MouseClicked(MouseButton.RightButton)) {
                    myDrawing.SelectShapesAt(mousePos);
                    Console.WriteLine("Right MB");
                }

                // event on_key_SPACE
                if (SplashKit.KeyTyped(KeyCode.SpaceKey)) {
                    myDrawing.Background = SplashKit.RandomColor();
                    Console.WriteLine("Space Key");
                }

                // event on_key_BACKSPACE or on_key_DELETE
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey)) {
                    if (SplashKit.KeyTyped(KeyCode.BackspaceKey)) {
                        Console.WriteLine("Backspace Key");
                    } if (SplashKit.KeyTyped(KeyCode.DeleteKey)) {
                        Console.WriteLine("Delete Key");
                    }
                    foreach (Shape s in myDrawing.SelectedShapes) {
                        myDrawing.RemoveShape(s);
                    }
                }

                // event on_key_L
                if (SplashKit.KeyTyped(KeyCode.LKey)) {
                    Console.WriteLine(myDrawing.ShapeCount);
                }

                // draw myDrawing
                myDrawing.Draw();
                
                // refresh screen
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
