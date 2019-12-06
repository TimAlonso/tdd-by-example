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

        public void Times(int multiplier)
        {
            _amount *= multiplier;
        }
    }
}
