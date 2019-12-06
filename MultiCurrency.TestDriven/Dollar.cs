using System;

namespace MultiCurrency.TestDriven
{
    public class Dollar
    {
        public int _amount;

        public Dollar(int amount)
        {
            _amount = amount;
        }

        public Dollar Times(int multiplier)
        {
            return new Dollar(_amount * multiplier);
        }
    }
}
