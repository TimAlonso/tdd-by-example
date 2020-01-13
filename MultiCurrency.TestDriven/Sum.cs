namespace MultiCurrency.TestDriven
{
    public class Sum : IExpression
    {
        public Sum(IExpression augend, IExpression addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public IExpression Augend { get; set; }
        public IExpression Addend { get; set; }

        public Money Reduce(Bank bank, string to)
        {
            int amount = Augend.Reduce(bank, to).Amount + Addend.Reduce(bank, to).Amount;
            return new Money(amount, to);
        }

        public IExpression Plus(IExpression addend)
        {
            return null;
        }
    }
}