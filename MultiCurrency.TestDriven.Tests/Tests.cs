using NUnit.Framework;

namespace MultiCurrency.TestDriven.Tests
{
    public class Tests
    {
        [Test]
        public void TestMultiplication()
        {
            Dollar five = new Dollar(5);
            five.Times(2);
            Assert.That(five._amount, Is.EqualTo(10));
        }
    }
}