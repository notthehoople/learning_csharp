using System;

namespace CSharpIntermediate
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            // Forced example of using a static method. No real need to do it like this:
            var person = new Person("Mark");
            person.Introduce("Jim");

            var customer = new Customer(1, "John");
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Name);
        }
    }
}
