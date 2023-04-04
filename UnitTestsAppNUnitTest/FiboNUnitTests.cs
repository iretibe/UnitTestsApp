using NUnit.Framework;
using UnitTestsApp;

namespace UnitTestsAppNUnitTest
{
    [TestFixture]
    public class FiboNUnitTests
    {
        [Test]
        public void FiboChecker_Input1_ReturnFiboSeries()
        {
            List<int> fiboSeries = new() { 0 };

            Fibo fibo = new ();
            fibo.Range = 1;

            List<int> result = fibo.GetFiboSeries();

            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.EquivalentTo(fiboSeries));
        }

        [Test]
        public void FiboChecker_Input6_ReturnFiboSeries()
        {
            List<int> fiboSeries = new() { 0, 1, 1, 2, 3, 5 };

            Fibo fibo = new();
            //fibo.Range = 3;
            fibo.Range = 6;

            List<int> result = fibo.GetFiboSeries();

            Assert.That(result, Does.Contain(3));
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result, Has.No.Member(4));
            Assert.That(result, Is.EquivalentTo(fiboSeries));
        }
    }
}
