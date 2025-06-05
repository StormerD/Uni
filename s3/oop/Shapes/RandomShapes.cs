using System.Drawing;
using SplashKitSDK;

namespace ShapeDrawer {
  public static class RandomShapeDrawer {
    public static void AddRandomShapes(Drawing drawing, int winWidth, int winHeight) {
      Random rand = new Random();
      int shapeCount = rand.Next(1, 5); // Draw between 1 and 5 shapes
      for (int i = 0; i < shapeCount; i++) {
        SplashKitSDK.Color randomColor = SplashKit.RandomRGBColor(255);
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
        drawing.AddShape(shape);
      }
      Console.WriteLine(shapeCount + " Random Shapes Added!");
    }
  }
}