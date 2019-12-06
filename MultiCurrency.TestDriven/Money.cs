namespace MultiCurrency.TestDriven
{
    public abstract class Money
    {
        protected int Amount;
        protected string _currency;

        public string Currency()
        {
            return _currency;
        }

        public abstract Money Times(int multiplier);

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
                   GetType() == money.GetType();
        }
    }
}