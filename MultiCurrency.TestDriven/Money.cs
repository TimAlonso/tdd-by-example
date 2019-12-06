namespace MultiCurrency.TestDriven
{
    public class Money
    {
        public int Amount;

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return Amount == money.Amount && 
                   GetType() == money.GetType();
        }
    }
}