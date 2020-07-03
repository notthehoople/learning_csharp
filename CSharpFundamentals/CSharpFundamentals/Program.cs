using CSharpFundamentals.Math;
using System;

namespace CSharpFundamentals
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            Person mark = new Person();
            mark.FirstName = "Mark";
            mark.LastName = "Bradshaw";
            mark.Introduce();

            Calculator calculator = new Calculator();
            var result = calculator.Add(1, 2);

            Console.WriteLine("Result of add: " + result);
        }
    }
}
