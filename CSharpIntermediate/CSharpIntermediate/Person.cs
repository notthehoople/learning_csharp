using System;

namespace CSharpIntermediate
{
    public class Person
    {
        // Fields in the class
        public int Id;
        public string FirstName;
        public string LastName;
        public DateTime Birthdate;

        // Methods in the class
        // Class constructor
        public Person(string firstName)
        {
            this.FirstName = firstName;
        }

        public void Introduce(string to)
        {
            Console.WriteLine("Hi {0}, I am {1}", to, FirstName);
        }

        // Example of a static method
        public static Person Parse(string str)
        {
            var person = new Person(str);

            return person;
        }
    }
}
