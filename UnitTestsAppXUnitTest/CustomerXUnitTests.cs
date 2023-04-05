using UnitTestsApp;
using Xunit;

namespace UnitTestsAppXUnitTest
{
    public class CustomerXUnitTests
    {
        private Customer customer;
        
        public CustomerXUnitTests()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastNames_ReturnFullNameXUnit()
        {
            //Arrange

            //Act
            customer.GreetAndCombineNames("Abdul Djalal", "Yessoufou");

            //Assert
            Assert.Equal("Hello, Abdul Djalal Yessoufou", customer.greetMessage);
            Assert.Contains("Abdul Djalal Yessoufou", customer.greetMessage);
            Assert.StartsWith("Hello,", customer.greetMessage);
            Assert.EndsWith("Yessoufou", customer.greetMessage);
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.greetMessage);
        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNullXUnit()
        {
            //Arrange

            //Act

            //Assert
            Assert.Null(customer.greetMessage);
        }

        [Fact]
        public void DiscountCHeck_DefaultCustomer_ReturnsDiscountInRangeXUnit()
        {
            int result = customer.Discount;

            Assert.InRange(result, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNullXUnit()
        {
            customer.GreetAndCombineNames("abdul Djalal", "");

            Assert.NotNull(customer.greetMessage);
            Assert.False(string.IsNullOrEmpty(customer.greetMessage));
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Orders_ReturnsBasicCustomerXUnit()
        {
            customer.OrderTotal = 10;

            var result = customer.GetCustomerDetails();

            Assert.IsType< BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Orders_ReturnsPlatinumCustomerXUnit()
        {
            customer.OrderTotal = 110;

            var result = customer.GetCustomerDetails();

            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
