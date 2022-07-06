using System;
using TestTraining;
using Xunit;

namespace Calculations.Tests
{
    [Collection("Customer")]
    public class CustomerTests
    {
        private readonly CustomerFixture _customerFixture;
        public CustomerTests(CustomerFixture customerFixture)
        {
            this._customerFixture = customerFixture;
        }

        //[Fact]
        //public void CheckNameNotEmpty()
        //{
        //    var customer = new Customer();
        //    Assert.NotNull(customer.Name);
        //    Assert.False(string.IsNullOrEmpty(customer.Name));
        //}

        [Fact]
        public void CheckLegitForDiscount()
        {
            var customer = this._customerFixture.Cstmr;
            Assert.InRange(customer.Age, 23, 41);
        }

        [Fact]
        public void GetOrderByNameNotNull()
        {
            var customer = this._customerFixture.Cstmr;
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(""));
            Assert.Equal("Error Khordi ke ? ", exceptionDetails.Message);
        }

        [Fact]
        public void LoyalCustomerForOrderThatIsGreaterThan100()
        {
            var customer = CustomerFactory.CreateCustomerInstance(109);
            var loyalCustomer = Assert.IsType<LoyalCustomer>(customer);
            Assert.Equal(9,loyalCustomer.Discount);
        }
    }
}
