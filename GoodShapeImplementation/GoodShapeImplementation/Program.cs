using System;
using System.Collections.Generic;

namespace GoodShapeImplementation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var shapes = new List<Shape>();
            shapes.Add(new Circle());
            shapes.Add(new Rectangle());
            shapes.Add(new Triangle());

            var canvas = new Canvas();
            canvas.DrawShapes(shapes);
        }
    }
}
