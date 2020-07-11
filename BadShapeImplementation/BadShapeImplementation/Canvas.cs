using System;
using System.Collections.Generic;

namespace OOP
{
    public class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            // Not a great implementation. This has tight coupling between ShapeType and Canvas since if one changes so does the other
            // Encapsulation is also broken, as the behaviour of each Shape is reliant on another class (Canvas)
            foreach (var shape in shapes)
                {
                switch (shape.Type)
                {
                    case ShapeType.Circle:
                        System.Console.WriteLine("Draw a circle");
                        break;
                    case ShapeType.Rectangle:
                        System.Console.WriteLine("Draw a rectangle");
                        break;
                }
            }
        }
    }
}
