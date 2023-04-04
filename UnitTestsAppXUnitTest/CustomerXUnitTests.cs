//using UnitTestsApp;

//namespace UnitTestsAppXUnitTest
//{
//    [TestFixture]
//    public class CustomerXUnitTests
//    {
//        private Customer customer;

//        [SetUp]
//        public void Setup()
//        {
//            customer = new Customer();
//        }

//        [Test]
//        public void CombineName_InputFirstAndLastNames_ReturnFullName()
//        {
//            //Arrange

//            //Act
//            string fullName = customer.GreetAndCombineNames("Abdul Djalal", "Yessoufou");

//            //Assert
//            Assert.AreEqual(fullName, "Hello, Abdul Djalal Yessoufou");
//            Assert.That(fullName, Is.EqualTo("Hello, Abdul Djalal Yessoufou"));
//            Assert.That(fullName, Does.Contain(","));
//            //Assert.That(fullName, Does.Contain("abdul Djalal Yessoufou"));
//            Assert.That(fullName, Does.Contain("abdul Djalal Yessoufou").IgnoreCase);
//            Assert.That(fullName, Does.StartWith("Hello,"));
//            Assert.That(fullName, Does.EndWith("Yessoufou"));
//            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));

//            //Assert.Multiple(() =>
//            //{
//            //    Assert.AreEqual(fullName, "Hello, Abdul Djalal Yessoufou");
//            //    Assert.That(fullName, Is.EqualTo("Hello, Abdul Djalal Yessoufou"));
//            //    Assert.That(fullName, Does.Contain(","));
//            //    //Assert.That(fullName, Does.Contain("abdul Djalal Yessoufou"));
//            //    Assert.That(fullName, Does.Contain("abdul Djalal Yessoufou").IgnoreCase);
//            //    Assert.That(fullName, Does.StartWith("Hello,"));
//            //    Assert.That(fullName, Does.EndWith("Yessoufou"));
//            //    Assert.That(fullName, Does.StartWith("1Hello,"));
//            //    Assert.That(fullName, Does.EndWith("1Yessoufou"));
//            //    Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
//            //});
//        }

//        [Test]
//        public void GreetMessage_NotGreeted_ReturnsNull()
//        {
//            //Arrange

//            //Act

//            //Assert
//            Assert.IsNull(customer.greetMessage);
//        }

//        [Test]
//        public void CombineName_InputFirstAndLastNames_ReturnGreatMessageFullName()
//        {
//            //Arrange
//            var customer = new Customer();

//            //Act
//            customer.GreetAndCombineNames("Abdul Djalal", "Yessoufou");

//            //Assert
//            Assert.AreEqual(customer.greetMessage, "Hello, Abdul Djalal Yessoufou");
//            Assert.That(customer.greetMessage, Is.EqualTo("Hello, Abdul Djalal Yessoufou"));
//            Assert.That(customer.greetMessage, Does.Contain(","));
//            Assert.That(customer.greetMessage, Does.Contain("abdul Djalal Yessoufou").IgnoreCase);
//            Assert.That(customer.greetMessage, Does.StartWith("Hello,"));
//            Assert.That(customer.greetMessage, Does.EndWith("Yessoufou"));
//            Assert.That(customer.greetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
//        }

//        [Test]
//        public void DiscountCHeck_DefaultCustomer_ReturnsDiscountInRange()
//        {
//            int result = customer.Discount;

//            Assert.That(result, Is.InRange(10, 25));
//        }

//        [Test]
//        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
//        {
//            customer.GreetAndCombineNames("abdul Djalal", "");

//            Assert.IsNotNull(customer.greetMessage);
//            Assert.IsFalse(string.IsNullOrEmpty(customer.greetMessage));
//        }

//        [Test]
//        public void GreetChecker_EmptyFirstName_ThrowsException()
//        {
//            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Yessoufou"));
            
//            Assert.AreEqual("Empty First Name", exceptionDetails.Message);
//            Assert.That(() => customer.GreetAndCombineNames("", "Yessoufou"), Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

//            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Yessoufou"));
//            Assert.That(() => customer.GreetAndCombineNames("", "Yessoufou"), Throws.ArgumentException);
//        }

//        [Test]
//        public void CustomerType_CreateCustomerWithLessThan100Orders_ReturnsBasicCustomer()
//        {
//            customer.OrderTotal = 10;

//            var result = customer.GetCustomerDetails();

//            Assert.That(result, Is.TypeOf<BasicCustomer>());
//        }

//        [Test]
//        public void CustomerType_CreateCustomerWithMoreThan100Orders_ReturnsPlatinumCustomer()
//        {
//            customer.OrderTotal = 130;

//            var result = customer.GetCustomerDetails();

//            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
//        }
//    }
//}
