namespace MultiCurrency.TestDriven
{
    public class Money
    {
        protected int Amount;
        protected string _currency;

        public Money(int amount, string currency)
        {
            Amount = amount;
            _currency = currency;
        }
        
        public string Currency()
        {
            return _currency;
        }

        public Money Times(int multiplier)
        {
            return new Money(Amount * multiplier, _currency);
        }

        public static Dollar Dollar(int amount)
        {
            return new Dollar(amount, "USD");
        }

        public static Franc Franc(int amount)
        {
            return new Franc(amount, "CHF");
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return Amount == money.Amount && 
                   _currency.Equals(money.Currency());
        }

        public override string ToString()
        {
            return Amount + " " + _currency;
        }
    }
}