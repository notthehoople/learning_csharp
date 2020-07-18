using System;
namespace Generics
{
    public class Utilities<T> where T : IComparable, new()
    {
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        // Generic version of this
        // where T : IComparable is a constraint
        // the contraint could be on the class instead of the method
        // generic method inside a non-generic class is fine

        // where T : IComparable
        // where T : Product
        // where T : struct (is a valueType)
        // where T : class (reference type)
        // where T : new() (is a contruct)

        public T GenericMax<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public void DoSomething(T value)
        {
            // Instantiate an instance of type T
            // var obj = new T(); Can't work as the compiler doesn't know what T is
            // Can add a second constraint to the class to make this possible e.g. new() above

            var obj = new T();          // Now works because we have a constraint of new() on the class
        }
    }
}
