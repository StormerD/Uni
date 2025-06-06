using SplashKitSDK;

namespace ShapeDrawer {
  public static class Utilities {
    public static void ScaleAllShapes(Drawing drawing, float scaleFactor) {
      foreach (Shape s in drawing.Shapes) {
        if (s is MyRectangle r) {
          r.Width = Convert.ToSingle(r.Width * scaleFactor);
          r.Height = Convert.ToSingle(r.Height * scaleFactor);
        }
        else if (s is MyCircle c) {
          c.Radius = Convert.ToSingle(c.Radius * scaleFactor);
        }
        else if (s is MyLine l) {
          l.Length = Convert.ToSingle(l.Length * scaleFactor);
        }
      }    
    }


    public static void DrawName(Drawing drawing, float baseX, float baseY, Color color) {

      // -- DRAW D --

      // Vertical line (as a rectangle)
      MyRectangle left = new MyRectangle();
      left.X = baseX;
      left.Y = baseY;
      left.Width = 20;
      left.Height = 60;
      left.Color = color;
      drawing.AddShape(left);

      // Top curve (as a circle)
      MyCircle Dtop = new MyCircle();
      Dtop.X = baseX + 20;
      Dtop.Y = baseY + 20;
      Dtop.Radius = 20;
      Dtop.Color = color;
      drawing.AddShape(Dtop);

      // Bottom curve (as a circle)
      MyCircle Dbottom = new MyCircle();
      Dbottom.X = baseX + 20;
      Dbottom.Y = baseY + 39;
      Dbottom.Radius = 20;
      Dbottom.Color = color;
      drawing.AddShape(Dbottom);

      // Middle curve (as a circle)
      MyCircle Dmiddle = new MyCircle();
      Dmiddle.X = baseX + 23;
      Dmiddle.Y = baseY + 30;
      Dmiddle.Radius = 20;
      Dmiddle.Color = color;
      drawing.AddShape(Dmiddle);

      // -- DRAW Y --
      baseX += 50; // Move baseX for the next shape

      // Left vertical line (as a rectangle)
      MyRectangle Yleft = new MyRectangle();
      Yleft.X = baseX;
      Yleft.Y = baseY + 20;
      Yleft.Width = 5;
      Yleft.Height = 15;
      Yleft.Color = color;
      drawing.AddShape(Yleft);

      // Top horizontal line (as a rectangle)
      MyRectangle Ytop = new MyRectangle();
      Ytop.X = baseX + 5;
      Ytop.Y = baseY + 35;
      Ytop.Width = 20;
      Ytop.Height = 5;
      Ytop.Color = color;
      drawing.AddShape(Ytop);

      // Right vertical line (as a rectangle)
      MyRectangle Yright = new MyRectangle();
      Yright.X = baseX + 25;
      Yright.Y = baseY + 20;
      Yright.Width = 5;
      Yright.Height = 45;
      Yright.Color = color;
      drawing.AddShape(Yright);

      // Bottom diagonal line (as a rectangle)
      MyRectangle Ybottom = new MyRectangle();
      Ybottom.X = baseX + 5;
      Ybottom.Y = baseY + 65;
      Ybottom.Width = 20;
      Ybottom.Height = 5;
      Ybottom.Color = color;
      drawing.AddShape(Ybottom);

      // -- DRAW L --
      baseX += 40; // Move baseX for the next shape

      // Vertical line (as a rectangle)
      MyRectangle Lleft = new MyRectangle();
      Lleft.X = baseX;
      Lleft.Y = baseY;
      Lleft.Width = 5;
      Lleft.Height = 60;
      Lleft.Color = color;
      drawing.AddShape(Lleft);

      // -- DRAW A --
      baseX += 15; // Move baseX for the next shape

      // Left vertical line (as a rectangle)
      MyRectangle Aleft = new MyRectangle();
      Aleft.X = baseX;
      Aleft.Y = baseY + 25;
      Aleft.Width = 5;
      Aleft.Height = 35;
      Aleft.Color = color;
      drawing.AddShape(Aleft);

      // Top horizontal line (as a rectangle)
      MyRectangle Atop = new MyRectangle();
      Atop.X = baseX + 5;
      Atop.Y = baseY + 20;
      Atop.Width = 20;
      Atop.Height = 5;
      Atop.Color = color;
      drawing.AddShape(Atop);

      // Right vertical line (as a rectangle)
      MyRectangle Aright = new MyRectangle();
      Aright.X = baseX + 25;
      Aright.Y = baseY + 25;
      Aright.Width = 5;
      Aright.Height = 35;
      Aright.Color = color;
      drawing.AddShape(Aright);

      // Middle horizontal line (as a rectangle)
      MyRectangle Amiddle = new MyRectangle();
      Amiddle.X = baseX + 5;
      Amiddle.Y = baseY + 40;
      Amiddle.Width = 20;
      Amiddle.Height = 5;
      Amiddle.Color = color;
      drawing.AddShape(Amiddle);

      // -- DRAW N --
      baseX += 40; // Move baseX for the next shape

      // Left vertical line (as a rectangle)
      MyRectangle Nleft = new MyRectangle();
      Nleft.X = baseX;
      Nleft.Y = baseY + 30;
      Nleft.Width = 5;
      Nleft.Height = 30;
      Nleft.Color = color;
      drawing.AddShape(Nleft);

      // Top horizontal line (as a rectangle)
      MyRectangle Ntop = new MyRectangle();
      Ntop.X = baseX + 5;
      Ntop.Y = baseY + 25;
      Ntop.Width = 20;
      Ntop.Height = 5;
      Ntop.Color = color;
      drawing.AddShape(Ntop);

      // Right vertical line (as a rectangle)
      MyRectangle Nright = new MyRectangle();
      Nright.X = baseX + 25;
      Nright.Y = baseY + 30;
      Nright.Width = 5;
      Nright.Height = 30;
      Nright.Color = color;
      drawing.AddShape(Nright);
    }

    public static void AddRandomShapes(Drawing drawing, int winWidth, int winHeight) {
      Random rand = new Random();
      int shapeCount = rand.Next(1, 5); // Draw between 1 and 5 shapes
      for (int i = 0; i < shapeCount; i++) {
        SplashKitSDK.Color randomColor = SplashKit.RandomRGBColor(255);
        Shape shape;
        float x = rand.Next(0, winWidth);
        float y = rand.Next(0, winHeight);
        int shapeType = rand.Next(0, 3); // 0 for Rectangle, 1 for Circle, 2 for Line

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