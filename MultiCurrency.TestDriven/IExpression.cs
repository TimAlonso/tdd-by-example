namespace MultiCurrency.TestDriven
{
    public interface IExpression
    {
        Money Reduce(Bank bank, string to);
    }
}