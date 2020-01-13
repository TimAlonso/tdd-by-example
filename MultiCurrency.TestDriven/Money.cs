namespace MultiCurrency.TestDriven
{
    public class Money : IExpression
    {
        public Money(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public string Currency { get; set; }

        public int Amount { get; set; }

        public IExpression Plus(Money addend)
        {
            return new Sum(this, addend);
        }

        public Money Reduce(Bank bank, string to)
        {
            var rate = bank.Rate(Currency, to);
            return new Money(Amount / rate, to);
        }

        public Money Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
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
            return Amount == money.Amount && 
                   Currency.Equals(money.Currency);
        }

        public override string ToString()
        {
            return Amount + " " + Currency;
        }
    }
}