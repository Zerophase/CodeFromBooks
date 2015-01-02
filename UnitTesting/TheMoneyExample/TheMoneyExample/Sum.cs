using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMoneyExample_TDD
{
	public class Sum : Expression
	{
		public Expression augend;
		public Expression addend;

		public Sum(Expression augend, Expression addend)
		{
			this.augend = augend;
			this.addend = addend;
		}

		public Expression plus(Expression addend)
		{
			return new Sum(this, addend);
		}

		public Expression times(int multiplier)
		{
			return new Sum(augend.times(multiplier), addend.times(multiplier));
		}

		public Money reduce(string to)
		{
			int amount = augend.reduce(to).amount 
				+ addend.reduce(to).amount;
			return new Money(amount, to);
		}

		public Money reduce(Bank bank, string to)
		{
			int amount = augend.reduce(bank, to).amount 
				+ addend.reduce(bank, to).amount;
			return new Money(amount, to);
		}
	}
}
