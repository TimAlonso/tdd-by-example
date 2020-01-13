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
            Assert.That(Money.Dollar(1).Currency, Is.EqualTo("USD"));
            Assert.That(Money.Franc(1).Currency, Is.EqualTo("CHF"));
        }

        [Test]
        public void TestSimpleAddition()
        {
            var five = Money.Dollar(5);
            var sum = five.Plus(five);
            var bank = new Bank();
            var reduced = bank.Reduce(sum, "USD");
            Assert.That(reduced, Is.EqualTo(Money.Dollar(10)));
        }
        
        [Test]
        public void TestPlusReturnsSum()
        {
            var five = Money.Dollar(5);
            var result = five.Plus(five);
            var sum = (Sum) result;
            Assert.That(sum.Augend, Is.EqualTo(five));
            Assert.That(sum.Addend, Is.EqualTo(five));
        }

        [Test]
        public void TestReducedSum()
        {
            IExpression sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            var bank = new Bank();
            var result = bank.Reduce(sum, "USD");
            Assert.That(result, Is.EqualTo(Money.Dollar(7)));
        }

        [Test]
        public void TestReduceMoney()
        {
            var bank = new Bank();
            var result = bank.Reduce(Money.Dollar(1), "USD");
            Assert.That(result, Is.EqualTo(Money.Dollar(1)));
        }

        [Test]
        public void TestReduceMoneyDifferentCurrency()
        {
            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            var result = bank.Reduce(Money.Franc(2), "USD");
            Assert.That(result, Is.EqualTo(Money.Dollar(1)));
        }

        [Test]
        public void TestIdentityRate()
        {
            Assert.That(new Bank().Rate("USD", "USD"), Is.EqualTo(1));
        }

        [Test]
        public void TestMixedAddition()
        {
            IExpression fiveBucks = Money.Dollar(5);
            IExpression tenFrancs = Money.Franc(10);

            var bank = new Bank();
            bank.AddRate("CHF", "USD", 2);

            Money result = bank.Reduce(fiveBucks.Plus(tenFrancs), "USD");
            Assert.That(result, Is.EqualTo(Money.Dollar(10)));
        }
    }
}