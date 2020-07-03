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
            // Object example
            Person mark = new Person();
            mark.FirstName = "Mark";
            mark.LastName = "Bradshaw";
            mark.Introduce();

            // Namespace example (note that we've added "using CSharpFundamentals.Math" at the top)
            Calculator calculator = new Calculator();
            var result = calculator.Add(1, 2);

            Console.WriteLine("Result of add: " + result);

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
            var shippingMethod = (ShippingMethod) Enum.Parse(typeof(ShippingMethod), methodName);

            // Reference and Value types example
            var playingWithTypes = new PlayingWithTypes();
            playingWithTypes.DoStuff();
        }
    }
}
