using Moq;
using UnitTestsApp;
using Xunit;

namespace UnitTestsAppXUnitTest
{
    public class ProductXUnitTests
    {
        [Fact]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20DiscountXUnit()
        {
            Product product = new Product()
            {
                Price = 50
            };

            var result = product.GetPrice(new Customer()
            {
                IsPlatinum = true
            });

            Assert.Equal(40, result);
        }

        [Fact]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20DiscountXUnit()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(c => c.IsPlatinum).Returns(true);

            Product product = new Product()
            {
                Price = 50
            };

            var result = product.GetPrice(customer.Object);

            Assert.Equal(40, result);
        }
    }
}
