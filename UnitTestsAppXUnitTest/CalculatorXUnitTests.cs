using UnitTestsApp;
using Xunit;

namespace UnitTestsAppXUnitTest
{
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumbers_InputTwoIntegers_GetCorrectAdditionXunit()
        {
            //Arrange
            Calculator calc = new();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void IsOddChecker_InputEvenNumber_ReturnFalseXunit()
        {
            //Arrange
            Calculator calc = new();

            //Act
            bool isOdd = calc.IsOddNumber(10);

            //Assert
            //Assert.That(isOdd, Is.EqualTo(false));
            Assert.False(isOdd);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsOddChecker_InputOddNumber_ReturnTrueXunit(int a)
        {
            //Arrange
            Calculator calc = new();

            //Act
            bool isOdd = calc.IsOddNumber(a);

            //Assert
            Assert.True(isOdd);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOddXunit(int a, bool expectedResult)
        {
            //Arrange
            Calculator calc = new();

            var result = calc.IsOddNumber(a);

            //Act and Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(5.4, 10.5)]
        //[InlineData(5.43, 10.53)]
        //[InlineData(5.49, 10.59)]
        public void AddDoubleNumbers_InputTwoDouble_GetCorrectAdditionXunit(double a, double b)
        {
            //Arrange
            Calculator calc = new();

            //Act
            double result = calc.AddDoubleNumbers(a, b);

            //Assert
            Assert.Equal(15.9, result, 2);
        }

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRangeXunit()
        {
            //Arrange
            Calculator calc = new();
            List<int> expectedOddRange = new() { 5, 7, 9 };

            //Act
            List<int> result = calc.GetOddRange(5, 10);

            //Assert
            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u => u), result);
        }
    }
}
