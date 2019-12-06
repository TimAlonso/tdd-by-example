namespace MultiCurrency.TestDriven
{
    public class Dollar : Money
    {
        public Dollar(int amount, string currency)
        {
            Amount = amount;
            _currency = currency;
        }

        public override Money Times(int multiplier)
        {
            return Dollar(Amount * multiplier);
        }
    }
}
