using System.Collections.Generic;

namespace CSharpIntermediate
{
    public class Customer
    {
        // Fields
        public int Id;
        public string Name;
        public readonly List<Order> Orders = new List<Order>();

        // Methods
        public Customer()
        {
            Orders = new List<Order>();
        }
            
        public Customer(int id)
            : this()
        {
            this.Id = id;
        }

        // calls the previous constructor with the id, then runs the code here
        public Customer(int id, string name)
            : this(id)
        {
            this.Name = name;
        }

        public void Promote()
        {
            // ....
        }
    }
}
