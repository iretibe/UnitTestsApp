using UnitTestsApp;

namespace UnitTestsAppMSTest
{
    [TestClass]
    public class CalculatorMSTest
    {
        [TestMethod]
        public void AddNumbers_InputTwoIntegers_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new ();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
