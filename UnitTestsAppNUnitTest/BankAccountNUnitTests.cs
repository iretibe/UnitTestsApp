using Moq;
using NUnit.Framework;
using UnitTestsApp;

namespace UnitTestsAppNUnitTest
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        //private BankAccount bankAccount;
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            //bankAccount = new(new LogBook());
            //bankAccount = new(new LogFaker());
        }

        //[Test]
        //public void BankDeposit_Add100_ReturnTrue()
        //{
        //    BankAccount bankAccount = new(new LogFaker());
        //    var result = bankAccount.Deposit(100);

        //    Assert.IsTrue(result);
        //    Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        //}

        [Test]
        public void BankDepositLogFaker_Add100_ReturnTrue()
        {
            BankAccount bankAccount = new(new LogFaker());
            var result = bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message(""));

            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Deposit(100);

            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(s => s.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(s => s.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bank = new(logMock.Object);
            bank.Deposit(balance);
            var result = bank.Withdraw(withdraw);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(200, 300)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(s => s.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            //logMock.Setup(s => s.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(s => s.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bank = new(logMock.Object);
            bank.Deposit(balance);
            var result = bank.Withdraw(withdraw);

            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();

            string strOutput = "hello";

            logMock.Setup(s => s.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());
            //logMock.Setup(s => s.MessageWithReturnStr("Hi")).Returns((string str) => str.ToLower());

            Assert.That(logMock.Object.MessageWithReturnStr("HELLO"), Is.EqualTo(strOutput));
        }

        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();

            string strOutput = "hello";

            logMock.Setup(s => s.LogWithOutputResult(It.IsAny<string>(), out strOutput)).Returns(true);

            string result = "";

            Assert.IsTrue(logMock.Object.LogWithOutputResult("Manane", out result));
            Assert.That(result, Is.EqualTo(strOutput));
        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();

            Customer customer = new ();
            Customer customerNotUsed = new ();

            logMock.Setup(s => s.LogWithRefObj(ref customer)).Returns(true);

            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
        }

        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeverityMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();

            logMock.SetupAllProperties();

            logMock.Setup(l => l.LogSeverity).Returns(10);
            logMock.Setup(l => l.LogType).Returns("Warning");
            
            logMock.Object.LogSeverity = 10;

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType, Is.EqualTo("Warning"));

            //Callbacks
            string logTemp = "Hello, ";
            logMock.Setup(l => l.LogToDb(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("Abdul");
            Assert.That(logTemp, Is.EqualTo("Hello, Abdul"));


            //Callbacks
            int counter = 5;
            logMock.Setup(l => l.LogToDb(It.IsAny<string>())).Returns(true).Callback(() => counter++);
            logMock.Object.LogToDb("Abdul");
            logMock.Object.LogToDb("Abdul");
            Assert.That(counter, Is.EqualTo(7));
        }

        [Test]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();

            BankAccount bankAccount = new (logMock.Object);
            bankAccount.Deposit(100);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

            //Verification
            logMock.Verify(l => l.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(l => l.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(l => l.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(l => l.LogSeverity, Times.Once);
        }
    }
}
