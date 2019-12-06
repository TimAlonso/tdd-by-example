﻿namespace MultiCurrency.TestDriven
{
    public class Money : IExpression
    {
        private readonly string _currency;

        public Money(int amount, string currency)
        {
            Amount = amount;
            _currency = currency;
        }
        
        public string Currency()
        {
            return _currency;
        }

        public int Amount { get; set; }

        public IExpression Plus(Money addend)
        {
            return new Sum(this, addend);
        }

        public Money Reduce(string to)
        {
            return this;
        }

        public Money Times(int multiplier)
        {
            return new Money(Amount * multiplier, _currency);
        }

        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return Amount == money.Amount && 
                   _currency.Equals(money.Currency());
        }

        public override string ToString()
        {
            return Amount + " " + _currency;
        }
    }

    public interface IExpression
    {
        Money Reduce(string to);
    }

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

    public class Bank
    {
        public Money Reduce(IExpression source, string to)
        {
            return source.Reduce(to);
        }
    }
}