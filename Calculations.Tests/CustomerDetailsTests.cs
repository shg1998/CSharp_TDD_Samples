using TestTraining;
using Xunit;

namespace Calculations.Tests
{
    [Collection("Customer")]
    public class CustomerDetailsTests
    {

        private readonly CustomerFixture _customerFixture;
        public CustomerDetailsTests(CustomerFixture customerFixture) => 
            this._customerFixture = customerFixture;

        [Fact]
        public void GetFullName_GivenFirstAndLastName_ReturnsFullName()
        {
            var customer = this._customerFixture.Cstmr;
            Assert.Equal("MohammadHossein Nejadhendi", customer.GetFullName("MohammadHossein", "Nejadhendi"));
        }
    }
}
