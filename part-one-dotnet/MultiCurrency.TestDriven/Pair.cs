namespace MultiCurrency.TestDriven
{
    public class Pair
    {
        public Pair(string from, string to)
        {
            From = from;
            To = to;
        }

        public string From { get; }
        public string To { get; }

        public override bool Equals(object obj)
        {
            var pair = (Pair) obj;
            return From.Equals(pair.From) && To.Equals(pair.To);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}