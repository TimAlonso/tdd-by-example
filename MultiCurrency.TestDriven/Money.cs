namespace MultiCurrency.TestDriven
{
    public abstract class Money
    {
        public int Amount;

        public abstract Money Times(int multiplier);

        public static Dollar Dollar(int amount)
        {
            return new Dollar(amount);
        }

        public static Franc Franc(int amount)
        {
            return new Franc(amount);
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return Amount == money.Amount && 
                   GetType() == money.GetType();
        }
    }
}