using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateCurrencyApplicationServices
{
	public class HelpCommand : ICommand
	{
		public void Execute()
		{
			Console.WriteLine("Usage: UpdateCurrency <DKK | EUR | USD> <DKK | EUR | USD> <rate>.");
		}
	}
}
