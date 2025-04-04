using System;
using SplashKitSDK;

namespace ShapeDrawer {
    public class Program {
        public static void Main() {

            // draw window
            Window window = new Window("Shape Drawer", 800, 600);

            // variables
            Shape myShape;
            Shape myTestEllipse;
            Shape myEllipse;
            Point2D mousePos;

            // setup variables
            myShape = new Shape(189, 0, 0);
            myTestEllipse = new Shape(150, 75, 75);
            myTestEllipse.Color = Color.Red;
            myEllipse = new Shape(100, 100, 100);
            mousePos = new Point2D(SplashKit.MouseX(), SplashKit.MouseY());

            do {
                // clear screen
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                // update 
                mousePos.X = SplashKit.MouseX();
                mousePos.Y = SplashKit.MouseY();

                // draw shapes
                myShape.DrawRectangle();
                myTestEllipse.DrawEllipse();
                myEllipse.DrawEllipse();

                // mouse_click event
                if (SplashKit.MouseClicked(MouseButton.LeftButton)) {
                    myShape.X = mousePos.X;
                    myShape.Y = mousePos.Y;
                }

                // key_pressed(space) && mouse_over(object) event
                if (SplashKit.KeyTyped(KeyCode.SpaceKey) && myShape.IsAt(mousePos)) {
                    myShape.Color = SplashKit.RandomColor();
                }

                // 
                if (myEllipse.InEllipse(mousePos.X, mousePos.Y)) {
                    myEllipse.Color = Color.Blue;
                }
                if (!myEllipse.InEllipse(mousePos.X, mousePos.Y)) {
                    myEllipse.Color = Color.Azure;
                }

                // draw shapes
                myShape.DrawRectangle();
                myEllipse.DrawEllipse();
                
                // refresh screen
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
