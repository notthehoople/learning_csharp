using CSharpFundamentals.Math;
using System;

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
