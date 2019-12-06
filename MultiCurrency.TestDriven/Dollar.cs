namespace MultiCurrency.TestDriven
{
    public class Dollar : Money
    {
        public Dollar(int amount, string currency) : 
            base(amount, currency)
        {
            Amount = amount;
            _currency = currency;
        }

        
    }
}
