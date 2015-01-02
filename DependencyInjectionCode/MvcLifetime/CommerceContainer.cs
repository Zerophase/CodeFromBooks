using System.Configuration;
using System.Web;
using System.Web.Mvc;
using Lifetime;
using MvcLifetime.Controllers;

namespace MvcLifetime
{
	// NOTE Web Request Context
	// guarantees each user gets a seperate query of the web server
	// so there is no need to wait in line behind other users
	public partial class CommerceContainer
	{
		public IController ResolveHomeController()
		{
			// Delegates resolution of DiscountRepository to separate method
			var discountPolicy =
				new RepositoryBasketDiscountPolicy(ResolveDiscountRepository());

			// Delegates resolution of DiscountRepository to separate method
			var campaign =
				new DiscountCampaign(ResolveDiscountRepository());

			return new HomeController(campaign, discountPolicy);
		}

		protected virtual DiscountRepository ResolveDiscountRepository()
		{
			// checks if desired instance exists, if so it uses it
			// keeps a singleton lifestyle for all shared dependencies
			var repository = HttpContext.Current.
				Items["DiscountRepository"] as DiscountRepository;
			// if desired instance doesn't exist create that instance
			// and associate it with the current web request
			if (repository == null)
			{
				var connStr = ConfigurationManager
					.ConnectionStrings["CommerceObjectContext"]
					.ConnectionString;
				repository = new SqlDiscountRepository(connStr);
				HttpContext.Current
					.Items["DiscountRepository"] = repository;
			}

			return repository;
		}
	}

	public partial class CommerceContainer : ICommerceContainer
	{
		
	}
}