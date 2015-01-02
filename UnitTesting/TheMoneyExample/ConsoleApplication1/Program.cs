using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMoneyExample_TDD;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			Bank bank = new Bank();

			bank.addRate("USD", "HIH", 3);
			bank.addRate("USD", "CHF", 2);

			int rate = bank.rate("USD", "CHF");

			Console.WriteLine("rate is " + rate);
			Console.ReadKey();
		}
	}
}
