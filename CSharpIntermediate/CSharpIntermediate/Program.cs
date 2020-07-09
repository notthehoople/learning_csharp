using System;

namespace CSharpIntermediate
{
    public class Person
    {
        // Fields in the class
        public string Name;

        // Methods in the class
        // Class constructor
        public Person(string name)
        {
            this.Name = name;
        }

        public void Introduce(string to)
        {
            Console.WriteLine("Hi {0}, I am {1}", to, Name);
        }

        // Example of a static method
        public static Person Parse(string str)
        {
            var person = new Person(str);

            return person; 
        }
    }

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
