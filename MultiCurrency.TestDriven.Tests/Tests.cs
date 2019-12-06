using NUnit.Framework;

namespace MultiCurrency.TestDriven.Tests
{
    public class Tests
    {
        [Test]
        public void TestMultiplication()
        {
            var five = Money.Dollar(5);
            Assert.That(five.Times(2), Is.EqualTo(Money.Dollar(10)));
            Assert.That(five.Times(3), Is.EqualTo(Money.Dollar(15)));
        }

        [Test]
        public void TestEquality()
        {
            Assert.That(Money.Dollar(5).Equals(Money.Dollar(5)), Is.True);
            Assert.That(Money.Dollar(5).Equals(Money.Dollar(6)), Is.False);
            Assert.That(Money.Dollar(5).Equals(Money.Franc(5)), Is.False);
        }

        [Test]
        public void TestCurrencies()
        {
            Assert.That(Money.Dollar(1).Currency(), Is.EqualTo("USD"));
            Assert.That(Money.Franc(1).Currency(), Is.EqualTo("CHF"));
        }
    }
}