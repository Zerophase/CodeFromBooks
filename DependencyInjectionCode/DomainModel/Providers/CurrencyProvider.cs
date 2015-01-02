using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Providers
{
	public abstract class CurrencyProvider
	{
		public abstract Currency  GetCurrency(string currencyCode);
	}
}
