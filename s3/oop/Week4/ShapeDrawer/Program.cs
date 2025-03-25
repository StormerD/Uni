using System;
using SplashKitSDK;

namespace ShapeDrawer {
    public class Program {
        public static void Main() {

            // draw window
            Window window = new Window("Shape Drawer", 800, 600);

            // variables
            Shape myShape;
            Point2D mousePos;

            // setup variables
            myShape = new Shape(189);
            mousePos = new Point2D(SplashKit.MouseX(), SplashKit.MouseY());

            do {
                // clear screen
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                // update 
                mousePos.X = SplashKit.MouseX();
                mousePos.Y = SplashKit.MouseY();

                // draw myShape
                myShape.Draw();


                // mouse_click event
                if (SplashKit.MouseClicked(MouseButton.LeftButton)) {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

                // key_pressed(space) && mouse_over(object) event
                if (SplashKit.KeyTyped(KeyCode.SpaceKey) && myShape.IsAt(mousePos)) {
                    myShape.Color = SplashKit.RandomColor();
                }

                // draw myShape
                myShape.Draw();
                
                // refresh screen
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
