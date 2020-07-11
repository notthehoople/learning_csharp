using System;
using System.Collections.Generic;

namespace StackExample
{
    public class Stack
    {
        private List<string> ItemList = new List<string>();

        public void Push(string input)
        {
            try
            {
                if (input is null)
                    throw new InvalidOperationException("Missing data to store");
                else
                {
                    if (input.Trim() == "")
                        throw new InvalidOperationException("Missing data to store");
                    else
                        ItemList.Add(input);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public string Pop()
        {
            try
            {
                if (ItemList.Count > 0)
                {
                    var i = ItemList[ItemList.Count - 1];
                    ItemList.Remove(i);
                    return i;
                }
                else
                {
                    throw new InvalidOperationException("The stack is empty");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }

        }

        public List<string> ShowList()
        {
            return ItemList;
        }

        public void Clear()
        {
            ItemList.Clear();
        }
    }
}