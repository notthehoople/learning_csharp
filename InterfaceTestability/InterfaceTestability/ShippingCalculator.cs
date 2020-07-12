namespace InterfaceTestability
{
    public interface IShippingCalculator
    {
        // Defines the capability that a class needs to provide
        float CalculateShipping(Order order);
    }

    // Define that this class will provide the capabilities needed by the interface IShipping Calculator
    public class ShippingCalculator : IShippingCalculator
    {
        public float CalculateShipping(Order order)
        {
            if (order.TotalPrice < 30f)
                return order.TotalPrice * 0.1f;

            return 0;
        }
    }
}
