namespace MultiCurrency.TestDriven
{
    public interface IExpression
    {
        Money Reduce(string to);
    }
}