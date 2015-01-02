using System.Configuration;
using CommerceSqlDataAccess;
using DomainModel.Providers;
using UpdateCurrencyApplicationServices;

namespace UpdateCurrency
{
	public class CurrencyContainer
	{
		// NOTE a container for command line
		// This custom container encapsulates how objects are composed
		// all this does is setup the types used by the container, and resolves
		// the types that implement the behaviour.
		// Once that's done the classes it sets up run the application.
		// THis only uses constructor injection

		// Composes types from three different application layers
		// and makes sure to map all abstractions to the correct classes
		public CurrencyParser ResolveCurrencyParser()
		{
			string connectionString = 
				ConfigurationManager.ConnectionStrings
				["CommerceObjectContext"].ConnectionString;

			CurrencyProvider provider =
				new SqlCurrencyProvider(connectionString);
			return new CurrencyParser(provider);
		}
	}
}