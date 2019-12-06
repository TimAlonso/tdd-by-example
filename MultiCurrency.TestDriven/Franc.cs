namespace MultiCurrency.TestDriven
{
    public class Franc : Money
    {
        public Franc(int amount, string currency) : 
            base(amount, currency)
        {
            Amount = amount;
            _currency = currency;
        }
    }
}