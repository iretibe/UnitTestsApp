using UnitTestsApp;
using Xunit;

namespace UnitTestsAppXUnitTest
{
    public class FiboXUnitTests
    {
        [Fact]
        public void FiboChecker_Input1_ReturnFiboSeriesXUnit()
        {
            List<int> fiboSeries = new() { 0 };

            Fibo fibo = new();
            fibo.Range = 1;

            List<int> result = fibo.GetFiboSeries();

            Assert.NotEmpty(result);
            Assert.Equal(result.OrderBy(u => u), result);
            Assert.True(result.SequenceEqual(fiboSeries));
        }

        [Fact]
        public void FiboChecker_Input6_ReturnFiboSeriesXUnit()
        {
            List<int> fiboSeries = new() { 0, 1, 1, 2, 3, 5 };

            Fibo fibo = new();
            //fibo.Range = 3;
            fibo.Range = 6;

            List<int> result = fibo.GetFiboSeries();

            Assert.Contains(3, result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(fiboSeries, result);
        }
    }
}
