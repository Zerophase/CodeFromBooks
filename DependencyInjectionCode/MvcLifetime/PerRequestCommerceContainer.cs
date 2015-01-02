using System.Configuration;
using System.Web.Mvc;
using Lifetime;
using MvcLifetime.Controllers;

namespace MvcLifetime
{
	// NOTE Per Request lifestyle
	// Combines the efficency of Singleton lifestyle,
	// and safety of transient lifestyle
	// Can be used in non-threadsafe instances, since
	// we're guaranteed that all consumers of the singleton
	// are only running in the same thread
	// When one or more consumers spin up a new thread transient is
	// still preferable.
	public class PerRequestCommerceContainer : ICommerceContainer
	{
		public IController ResolveHomeController()
		{
			var connStr = ConfigurationManager.
				ConnectionStrings["CommerceObjectContext"].
				ConnectionString;
			// acts as a locally scoped singleton
			var repository = new SqlDiscountRepository(connStr);

			// instance of repository is only shared with objects in this graph,
			// and not others
			var discountCampaign = new DiscountCampaign(repository);
			var discountPolicy = new RepositoryBasketDiscountPolicy(repository);

			return new HomeController(discountCampaign, discountPolicy);
		}
	}
}