using System;
using System.Collections.Generic;

namespace StackExample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Stack stack = new Stack();

            stack.Pop();
            PrintList("Popped 1 from empty list", stack.ShowList());
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            stack.Push("Fourth");
            PrintList("Added 4 items", stack.ShowList());
            stack.Pop();
            stack.Pop();
            PrintList("Popped 2 items", stack.ShowList());
            stack.Push("Fifth");
            PrintList("Added 1 item", stack.ShowList());
            stack.Clear();
            PrintList("Cleared the stack", stack.ShowList());
        }

        public static void PrintList(string message, List<string> stackList)
        {
            Console.WriteLine("===== {0} =====", message);
            foreach (var stackItem in stackList)
                Console.WriteLine("Item: {0}", stackItem);
        }
    }
}