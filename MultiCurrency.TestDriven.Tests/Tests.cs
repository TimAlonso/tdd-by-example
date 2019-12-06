using NUnit.Framework;

namespace MultiCurrency.TestDriven.Tests
{
    public class Tests
    {
        [Test]
        public void TestMultiplication()
        {
            Dollar five = new Dollar(5);
            Dollar product = five.Times(2);
            Assert.That(product._amount, Is.EqualTo(10));
            
            product = five.Times(3);
            Assert.That(product._amount, Is.EqualTo(15));
        }

        [Test]
        public void TestEquality()
        {
            Assert.That(new Dollar(5).Equals(new Dollar(5)), Is.True);
            Assert.That(new Dollar(5).Equals(new Dollar(6)), Is.False);
        }
    }
}