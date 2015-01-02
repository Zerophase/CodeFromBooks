using DomainModel;
using DomainModel.Providers;

namespace CommerceSqlDataAccess
{
	public class SqlCurrencyProvider : CurrencyProvider
	{
		private readonly string connString;

		public SqlCurrencyProvider(string connString)
		{
			this.connString = connString;
		}

		public override Currency GetCurrency(string currencyCode)
		{
			return new SqlCurrency(currencyCode, this.connString);
		}
	}
}