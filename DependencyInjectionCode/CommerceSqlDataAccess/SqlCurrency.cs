using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace CommerceSqlDataAccess
{
	public partial class SqlCurrency : Currency
	{
		private readonly string code;
		private readonly CommerceObjectContext context;

		public SqlCurrency(string currencyCode, string connString)
		{
			code = currencyCode;
			context = new CommerceObjectContext(connString);
		}

		public override string Code
		{
			get { return code; }
		}

		public override decimal GetExchangeRateFor(string currencyCode)
		{
			var rates = (from r in context.ExchangeRates
				where r.CurrencyCode == currencyCode
				      || r.CurrencyCode == code
				select r).ToDictionary(r => r.CurrencyCode);

			return rates[currencyCode].Rate/rates[code].Rate;
		}
	}

	public partial class SqlCurrency
	{
		public override void UpdateExchangeRate(string currencyCode, decimal rate)
		{
			var rates = (from r in this.context.ExchangeRates
						 where r.CurrencyCode == currencyCode
						 || r.CurrencyCode == this.code
						 || r.CurrencyCode == "DKK"
						 select r)
						 .ToDictionary(r => r.CurrencyCode);

			rates[currencyCode].Rate = rate * rates[this.code].Rate;
			this.context.SaveChanges();
		}
	}
}
