using NUnit.Framework;

namespace Summator.Tests
{
    public class Tests
    {
       private Summator summator;
        [SetUp]
        public void SetUp()
        {
            summator = new Summator();
        }
        [Test]
        public void TestSumNumersPositive()
        {
            //Arrange
            var values = new int[] { 5, 7 };
            //Act
            int result = summator.Sum(values);
            //Assert
            Assert.That(result == 12);
        }
        [Test]
        public void TestSumOneNumersPositive()
        {
            int result = summator.Sum(new int[] { 5 });
            Assert.That(result == 5);
        }
        [Test]
        public void TestSumNegative()
        {
            int result = summator.Sum(new int[] { -1, -10 });
            Assert.That(result == -11);
        }
        [Test]
        public void TestEmpty()
        {
            int result = summator.Sum(new int[] { });
            Assert.That(result == 0);
        }
        [Test]
        public void TestBigValues()
        {
            int result = summator.Sum(new int[] {2000000000, 2000000000, 2000000000 });
            Assert.AreEqual(result, 6000000000);
        }
        [TearDown]
        public void TearDown()
        {
            summator = null;
        }
    }
}