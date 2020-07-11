using System;
using System.Collections.Generic;

namespace GoodShapeImplementation
{
    public class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            // Better implementation, since the Draw method sits with the class of the shape
            // This class doesn't need to change when we add more shape types
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}
