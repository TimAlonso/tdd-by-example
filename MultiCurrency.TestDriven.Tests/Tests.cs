using NUnit.Framework;

namespace MultiCurrency.TestDriven.Tests
{
    public class Tests
    {
        [Test]
        public void TestMultiplication()
        {
            Dollar five = new Dollar(5);
            Assert.That(five.Times(2), Is.EqualTo(new Dollar(10)));
            Assert.That(five.Times(3), Is.EqualTo(new Dollar(15)));
        }

        [Test]
        public void TestFrancMultiplication()
        {
            Franc five = new Franc(5);
            Assert.That(five.Times(2), Is.EqualTo(new Franc(10)));
            Assert.That(five.Times(3), Is.EqualTo(new Franc(15)));
        }

        [Test]
        public void TestEquality()
        {
            Assert.That(new Dollar(5).Equals(new Dollar(5)), Is.True);
            Assert.That(new Dollar(5).Equals(new Dollar(6)), Is.False);
            Assert.That(new Franc(5).Equals(new Franc(5)), Is.True);
            Assert.That(new Franc(5).Equals(new Franc(6)), Is.False);
            Assert.That(new Dollar(5).Equals(new Franc(5)), Is.False);
        }
    }
}