using System;

namespace TestTraining
{
    public class Customer
    {
        public int GetOrdersByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Error Khordi ke ? ");
            return 100;
        }
        public int Age => 23;
    }

    public class LoyalCustomer : Customer
    {
        public int Discount { get; set; }

        public LoyalCustomer()
        {
            Discount = 9;
        }
    }

    public static class CustomerFactory
    {
        public static Customer CreateCustomerInstance(int orderCount) => 
            orderCount <= 100 ? new Customer() : new LoyalCustomer();
    }
}
