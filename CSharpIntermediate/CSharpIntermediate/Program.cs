using System;

namespace CSharpIntermediate
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            OverloadingMethods();
            StaticMethodExample();
            UseParamsModifier();
            UsingFields();
            Encapsulation1();
        }

        private static void Encapsulation1()
        {
            Console.WriteLine("===== Using Encapsulation =====");

            var person = new PersonEncapsulated();
            person.SetBirthdate(new DateTime(1999, 9, 28));

            Console.WriteLine("Birthdate is " + person.GetBirthdate());
        }

        private static void UsingFields()
        {
            Console.WriteLine("===== Using Fields =====");

            var customer = new Customer(1);
            customer.Orders.Add(new Order());
            customer.Orders.Add(new Order());
            Console.WriteLine("Number of orders: " + customer.Orders.Count);

            customer.Promote();
        }

        private static void UseParamsModifier()
        {
            Console.WriteLine("===== Use params modifier =====");

            var calculator = new Calculator();
            Console.WriteLine(calculator.Add(1, 2, 3, 4));
        }

        private static void StaticMethodExample()
        {
            // Forced example of using a static method. No real need to do it like this:
            Console.WriteLine("===== Using a static method =====");
            var person = new Person("Mark");
            person.Introduce("Jim");

            var customer = new Customer(1, "John");
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Name);
        }

        private static void OverloadingMethods()
        {
            try
            {
                Console.WriteLine("===== Overloading Methods =====");

                // using the Point class
                var point = new Point(10, 20);
                point.Move(new Point(40, 60));      // Overload 2
                Console.WriteLine("Point is at X: {0} Y: {1}", point.X, point.Y);

                point.Move(100, 200);               // Overload 1
                Console.WriteLine("Point is at X: {0} Y: {1}", point.X, point.Y);

                point.Move(null);                   // crash on purpose
            }
            catch (Exception)
            {
                Console.WriteLine("An unexpected error occurred");
            }
        }
    }
}
