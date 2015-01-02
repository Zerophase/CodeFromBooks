using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
	internal class CurrencyCacheEntry
	{
		private readonly decimal exchangeRate;
		private readonly DateTime expiration;

		internal CurrencyCacheEntry(decimal exchangeRate, DateTime expiration)
		{
			this.exchangeRate = exchangeRate;
			this.expiration = expiration;
		}

		internal decimal ExchangeRate
		{
			get { return exchangeRate; }
		}

		// NOTE How to use Ambient Context
		internal bool IsExpired
		{
			get { return TimeProvider.Current.UtcNow >= expiration; }
		}
	}
}
