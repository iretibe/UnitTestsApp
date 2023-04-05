using Moq;
using UnitTestsApp;
using Xunit;

namespace UnitTestsAppXUnitTest
{
    public class BankAccountXUnitFacts
    {
        private BankAccount account;

        [Fact]
        public void BankDeposit_Add100_ReturnTrueXUnit()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message(""));

            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Deposit(100);

            Assert.True(result);
            Assert.Equal(100, bankAccount.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrueXUnit(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(s => s.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(s => s.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bank = new(logMock.Object);
            bank.Deposit(balance);
            var result = bank.Withdraw(withdraw);

            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 300)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsTrueXUnit(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(s => s.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            //logMock.Setup(s => s.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(s => s.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bank = new(logMock.Object);
            bank.Deposit(balance);
            var result = bank.Withdraw(withdraw);

            Assert.False(result);
        }

        [Fact]
        public void BankLogDummy_LogMockString_ReturnTrueXUnit()
        {
            var logMock = new Mock<ILogBook>();

            string strOutput = "hello";

            logMock.Setup(s => s.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());
            //logMock.Setup(s => s.MessageWithReturnStr("Hi")).Returns((string str) => str.ToLower());

            Assert.Equal(strOutput, logMock.Object.MessageWithReturnStr("HELLO"));
        }

        [Fact]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrueXUnit()
        {
            var logMock = new Mock<ILogBook>();

            string strOutput = "hello";

            logMock.Setup(s => s.LogWithOutputResult(It.IsAny<string>(), out strOutput)).Returns(true);

            string result = "";

            Assert.True(logMock.Object.LogWithOutputResult("Manane", out result));
            Assert.Equal(strOutput, result);
        }

        [Fact]
        public void BankLogDummy_LogRefChecker_ReturnTrueXUnit()
        {
            var logMock = new Mock<ILogBook>();

            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(s => s.LogWithRefObj(ref customer)).Returns(true);

            Assert.True(logMock.Object.LogWithRefObj(ref customer));
            Assert.False(logMock.Object.LogWithRefObj(ref customerNotUsed));
        }

        [Fact]
        public void BankLogDummy_SetAndGetLogTypeAndSeverityMock_MockFactXUnit()
        {
            var logMock = new Mock<ILogBook>();

            logMock.SetupAllProperties();

            logMock.Setup(l => l.LogSeverity).Returns(10);
            logMock.Setup(l => l.LogType).Returns("Warning");

            logMock.Object.LogSeverity = 10;

            Assert.Equal(10, logMock.Object.LogSeverity);
            Assert.Equal("Warning", logMock.Object.LogType);

            //Callbacks
            string logTemp = "Hello, ";
            logMock.Setup(l => l.LogToDb(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("Abdul");
            Assert.Equal("Hello, Abdul", logTemp);


            //Callbacks
            int counter = 5;
            logMock.Setup(l => l.LogToDb(It.IsAny<string>())).Returns(true).Callback(() => counter++);
            logMock.Object.LogToDb("Abdul");
            logMock.Object.LogToDb("Abdul");
            Assert.Equal(7, counter);
        }

        [Fact]
        public void BankLogDummy_VerifyExampleXUnit()
        {
            var logMock = new Mock<ILogBook>();

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);
            Assert.Equal(100, bankAccount.GetBalance());

            //Verification
            logMock.Verify(l => l.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(l => l.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(l => l.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(l => l.LogSeverity, Times.Once);
        }
    }
}
