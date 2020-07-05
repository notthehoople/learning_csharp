using CSharpFundamentals.Math;
using System;
using System.Collections.Generic;

namespace CSharpFundamentals
{
    public enum ShippingMethod
    {
        RegularAirMail = 1,
        RegisteredAirMail = 2,
        Express = 3
    };

    class MainClass
    {
        public static void Main(string[] args)
        {
            ObjectExample();
            CalculatorExample();
            RandomExamples();
            EnumExamples();
            ReferenceAndValueTypes();
            WorkingWithArrays();
            WorkingWithLists();
        }

        private static void WorkingWithLists()
        {
            var numbers = new List<int>() { 1, 2, 3, 4 };

            Console.WriteLine("======= Lists ========");
            numbers.Add(1);                                 // Add an element to the list
            numbers.AddRange(new int[3] { 5, 1, 7 });       // Add multiple elements to a list

            foreach (var number in numbers)
                Console.WriteLine("Full List: " + number);

            Console.WriteLine("First Index of 1: " + numbers.IndexOf(1));
            Console.WriteLine("Last Index of 1: " + numbers.LastIndexOf(1));

            Console.WriteLine("Count of elements: " + numbers.Count);

            numbers.Remove(1);                              // Remove first occurrance of "1"
            foreach (var number in numbers)
                Console.WriteLine("Removed first 1. Element: " + number);

            // Remove all occurrances of 1
            for (var i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == 1)
                    numbers.Remove(numbers[i]);
            }

            foreach (var number in numbers)
                Console.WriteLine("Removed all 1s. Element: " + number);

            numbers.Clear();
            Console.WriteLine("Count of elements after Clear(): " + numbers.Count);
        }

        private static void WorkingWithArrays()
        {
            var numbers = new int[] { 3, 7, 9, 1, 14, 6 };      // "int" isn't needed as the type will be worked out

            Console.WriteLine("======= Arrays ========");

            Console.WriteLine("Length: " + numbers.Length);

            var index = Array.IndexOf(numbers, 9);
            Console.WriteLine("Index of 9 is " + index);

            // Clear: set elements to 0
            Array.Clear(numbers, 0, 2);
            foreach (var n in numbers)
                Console.WriteLine("Cleared Element {0}", n);

            var destinationArray = new int[3];
            Array.Copy(numbers, destinationArray, 3);
            foreach (var n in destinationArray)
                Console.WriteLine("Copied Element {0}", n);

            Array.Sort(numbers);
            foreach (var n in numbers)
                Console.WriteLine("Sorted Element {0}", n);

            Array.Reverse(numbers);
            foreach (var n in numbers)
                Console.WriteLine("Reversed Element {0}", n);
        }

        private static void ReferenceAndValueTypes()
        {
            // Reference and Value types example
            var playingWithTypes = new PlayingWithTypes();
            playingWithTypes.DoStuff();
        }

        private static void ObjectExample()
        {
            // Object example
            Person mark = new Person();
            mark.FirstName = "Mark";
            mark.LastName = "Bradshaw";
            mark.Introduce();
        }

        private static void CalculatorExample()
        {
            // Namespace example (note that we've added "using CSharpFundamentals.Math" at the top)
            Calculator calculator = new Calculator();
            var result = calculator.Add(1, 2);

            Console.WriteLine("Result of add: " + result);
        }

        private static void EnumExamples()
        {
            Console.WriteLine("======================");
            // enum examples
            var method = ShippingMethod.Express;
            Console.WriteLine("Enum examples");
            // print the shipping method
            Console.WriteLine(method);
            // print the integter that represents the Shipping method
            Console.WriteLine((int)method);

            // Cast back from an integer to the ShippingMethod
            var externalMethodId = 2;
            Console.WriteLine((ShippingMethod)externalMethodId);

            // Take a string representation of the shipping method and map it onto the enum
            var methodName = "Express";
            var shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);
            Console.WriteLine("======================");
        }

        private static void RandomExamples()
        {
            // Random character
            Console.WriteLine("======================");
            var random = new Random();
            Console.WriteLine("Random character: " + (char)random.Next((int)'a', (int)'z'));
            Console.WriteLine("Random character: " + (char)('a' + random.Next(0, 26)));

            const int passwordLength = 10;
            var buffer = new char[passwordLength];
            for (var i = 0; i < passwordLength; i++)
                buffer[i] = (char)('a' + random.Next(0, 26));

            var password = new string(buffer);
            Console.WriteLine("Password is: " + password);
            Console.WriteLine("======================");
        }
    }
}
