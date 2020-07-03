using System;

namespace CSharpFundamentals
{
    public class PlayingWithTypes
    {
        public void DoStuff()
        {
            Console.WriteLine("Playing with Types");
            // Value Types
            var a = 10;
            var b = a;
            b++;

            Console.WriteLine(string.Format("Value types: a: {0}, b: {1}", a, b));

            var array1 = new int[3] { 1, 2, 3 };
            var array2 = array1;
            array2[0] = 0;

            Console.WriteLine(string.Format("Reference types: array1[0]: {0}, array2[0]: {1}", array1[0], array2[0]));

            Console.WriteLine("Array1");
            Array.ForEach(array1, Console.WriteLine);
            Console.WriteLine("Array2");
            Array.ForEach(array2, Console.WriteLine);
        }
    }
}