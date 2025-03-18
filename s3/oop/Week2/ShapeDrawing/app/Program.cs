using System;
namespace ShapeDrawing {
    public class Program {
        static void Main(string[] args) {
            Shape myShape;

            myShape = new Shape(10);

            myShape.Draw();

            // check to see if point is on the shape
            if (myShape.IsAt(2, 9)) {
                Console.WriteLine("Is On Shape");
            }
            else {
                Console.WriteLine("Is NOT On Shape");
            }
        }
    }
}