using System.Collections.Generic;

namespace CSharpIntermediate
{
    public class Customer
    {
        // Fields
        public int Id;
        public string Name;
        public List<Order> Orders;

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

        public Customer(int id, string name)
            : this(id)
        {
            this.Name = name;
        }
    }
}
