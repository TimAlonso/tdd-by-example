using System;

namespace MultiCurrency.TestDriven
{
    public class Money
    {
        public int Amount;

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return Amount == money.Amount;
        }
    }

    public class Dollar : Money
    {
        public Dollar(int amount)
        {
            Amount = amount;
        }

        public Dollar Times(int multiplier)
        {
            return new Dollar(Amount * multiplier);
        }
    }

    public class Franc : Money
    {
        public Franc(int amount)
        {
            Amount = amount;
        }

        public Franc Times(int multiplier)
        {
            return new Franc(Amount * multiplier);
        }
    }
}
