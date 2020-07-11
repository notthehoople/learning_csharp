using System;
using System.Collections;
using System.Collections.Generic;

namespace OOP
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            ConstructorInheritance();
            Upcasting();
            Downcasting();
            BoxingAndUnboxing();
        }

        private static void BoxingAndUnboxing()
        {
            var list = new ArrayList();             // Performance impact ahead!
            list.Add(1);                            // Add takes type "object" so boxing will happen with value 1
            list.Add("Mark");                       // string is a reference type, so no boxing
            list.Add(DateTime.Today);               // Structure. Boxing happens here

            // Better way:

            var anotherList = new List<int>();      // Type safety created here, as the list must be of type "int"
            anotherList.Add(1);                     // The Add method expects an int here, so no boxing happens

            var names = new List<string>();         // Type safety again, list will be all reference types "string"
            names.Add("Mark");                      // No boxing happening here
        }

        private static void Downcasting()
        {
            Console.WriteLine("===== Downcasting =====");

            Shape shape = new Text();               // Object will be of type "Text" even though it's cast to Shape
                                                    // However "shape" will have a limited view caused by "Shape"
            Text text = (Text)shape;                // This allows full view of the class methods

            var otherText = shape as Text;
            if (otherText != null)
                Console.WriteLine("Successfully cast to Text");
            else
                Console.WriteLine("Cast to Text failed");
        }

        private static void Upcasting()
        {
            Text text = new Text();
            Shape shape = text;         // Upcasting

            text.Width = 200;
            shape.Width = 100;

            Console.WriteLine("===== Upcasting =====");

            Console.WriteLine("Width is: " + text.Width);

            // This shows the use of casting. ArrayList allows any object to be added to the list
            // Since "object" is the root of all objects, ANYTHING can be included in the list
            // This isn't safe code though, as it's difficult to deal with a list of random types.
            var list = new ArrayList();
            list.Add(1);
            list.Add("mark");
            list.Add(new Text());

            // Safer code, restricts the list to a single type
            var anotherList = new List<Shape>();
        }

        private static void ConstructorInheritance()
        {
            Console.WriteLine("===== Constructor Inheritance =====");
            var car = new Car("AB01 TFG");
        }
    }
}
