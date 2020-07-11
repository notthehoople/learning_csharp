using System;
using System.Collections.Generic;

namespace StackExample
{
    public class Stack
    {
        private readonly List<string> _itemList = new List<string>();

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
                        _itemList.Add(input);
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
                if (_itemList.Count > 0)
                {
                    var popItem = _itemList[_itemList.Count - 1];
                    _itemList.Remove(popItem);
                    return popItem;
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
            return _itemList;
        }

        public void Clear()
        {
            _itemList.Clear();
        }
    }
}