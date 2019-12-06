namespace MultiCurrency.TestDriven
{
    public class Sum : IExpression
    {
        public Sum(Money augend, Money addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Augend { get; set; }
        public Money Addend { get; set; }

        public Money Reduce(string to)
        {
            int amount = Augend.Amount + Addend.Amount;
            return new Money(amount, to);
        }
    }
}