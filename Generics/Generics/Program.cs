using System;
namespace Generics
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var book = new Book { Isbn = "1111", Title = "C# Advanced" };

            var dictionary = new GenericDictionary<string, Book>();
            dictionary.Add("1234", new Book());

            // Using Nullable
            var number = new Nullable<int>(5);
            Console.WriteLine("Has value ? " + number.HasValue);
            Console.WriteLine("Value: " + number.GetValueOrDefault());

            // Using Nullable
            var number2 = new Nullable<int>();
            Console.WriteLine("Has value ? " + number2.HasValue);
            Console.WriteLine("Value: " + number2.GetValueOrDefault());

            // This class is already available in System
            //   System.Nullable<T>
        }
    }
}
