using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMoneyExample_TDD
{
	public class Money : Expression
	{
		public int amount;
		protected string currency;
		public string Currency()
		{
			return currency;
		}

		public Money(int amount, string currency)
		{
			this.amount = amount;
			this.currency = currency;
		}

		public override string ToString()
		{
			return amount + " " + currency;
		}

		public Expression plus(Expression addend)
		{
			return new Sum(this, addend);
		}

		public Expression times(int multiplier)
		{
			return new Money(amount * multiplier, currency);
		}

		public Money reduce(string to)
		{
			int rate = (currency.Equals("CHF") && to.Equals("USD"))
				? 2 : 1;
			return new Money(amount / rate, to);
		}

		public Money reduce(Bank bank, string to)
		{
			int rate = bank.rate(currency, to);
			return new Money(amount / rate, to);
		}

		public static Money dollar(int amount)
		{
			return new Money(amount, "USD");
		}

		public static Money franc(int amount)
		{
			return new Money(amount, "CHF");
		}
		
		public override bool Equals(object obj)
		{
			Money money = (Money)obj;
			return amount == money.amount
				&& Currency().Equals(money.Currency());
		}
	}
}
