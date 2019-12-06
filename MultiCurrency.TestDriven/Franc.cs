namespace MultiCurrency.TestDriven
{
    public class Franc : Money
    {
        public Franc(int amount, string currency)
        {
            Amount = amount;
            _currency = currency;
        }

        public override Money Times(int multiplier)
        {
            return Franc(Amount * multiplier);
        }
    }
}