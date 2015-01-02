using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMoneyExample_TDD
{
	public interface Expression
	{
		Money reduce(string to);
		Money reduce(Bank bank, string to);
		Expression plus(Expression addend);
		Expression times(int multiplier);
	}
}
