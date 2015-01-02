using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateCurrency
{
	class Program
	{
		static void Main(string[] args)
		{
			var container = new CurrencyContainer();
			container.ResolveCurrencyParser().
				Parse(args).Execute();
		}
	}
}
