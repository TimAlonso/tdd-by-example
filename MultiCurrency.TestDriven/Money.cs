namespace MultiCurrency.TestDriven
{
    public class Money : IExpression
    {
        private readonly int _amount;
        private readonly string _currency;

        public Money(int amount, string currency)
        {
            _amount = amount;
            _currency = currency;
        }
        
        public string Currency()
        {
            return _currency;
        }

        public IExpression Plus(Money addend)
        {
            return new Money(_amount + addend._amount, _currency);
        }

        public Money Times(int multiplier)
        {
            return new Money(_amount * multiplier, _currency);
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return _amount == money._amount && 
                   _currency.Equals(money.Currency());
        }

        public override string ToString()
        {
            return _amount + " " + _currency;
        }
    }

    public interface IExpression
    {
    }

    public class Bank
    {
        public Money Reduce(IExpression source, string to)
        {
            return Money.Dollar(10);
        }
    }
}