using System;

namespace HelloWorld
{
    class PlayingWithVariables
    {
        public PlayingWithVariables(int option)
        {
            switch (option)
            {
                case 1:
                    BasicVariables();
                    break;
                case 2:
                    Conversions();
                    break;
                default:
                    Console.WriteLine("No handler for option " + option);
                    break;
            }
        }

        private static void BasicVariables()
        {
            const float Pi = 3.14f;

            byte number = 2;
            int count = 10;
            float totalPrice = 20.95f;
            char character = 'A';
            string firstName = "Mark";
            bool isWorking = true;

            Console.WriteLine("Basic Variables");
            Console.WriteLine("Number is " + number);
            Console.WriteLine(count);
            Console.WriteLine(totalPrice);
            Console.WriteLine(character);
            Console.WriteLine(firstName);
            Console.WriteLine(isWorking);

            Console.WriteLine("byte Min: {0} Max: {1}", byte.MinValue, byte.MaxValue);
        }

        private void Conversions()
        {
            Console.WriteLine("Conversions and basic try / catch");

            try
            {
                var number = "1234";
                byte b = Convert.ToByte(number);
                Console.WriteLine(b);       // Will create an exception if we don't handle it
            }
            catch (Exception)
            {
                Console.WriteLine("The number could not be converted to a byte.");
            }

            string str = "true";
            bool boolVar = Convert.ToBoolean(str);
            Console.WriteLine("Our converted boolean is " + boolVar);
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            var playingWithVariables = new PlayingWithVariables(2);

            Console.WriteLine("Hello World!");
        }
    }
}
