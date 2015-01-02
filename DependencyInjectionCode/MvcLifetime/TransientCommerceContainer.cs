using System.Configuration;
using System.Web.Mvc;
using Lifetime;
using MvcLifetime.Controllers;

namespace MvcLifetime
{
	// NOTE Transient Container
	public class TransientCommerceContainer : ICommerceContainer
	{

		public IController ResolveHomeController()
		{
			var connStr = ConfigurationManager
				.ConnectionStrings["CommerceObjectContext"]
				.ConnectionString;

			// Creates new instance of repository per object requested
			// Each request gets a seperate instance of SqlDiscountRepository
			var discountCampaign =
				new DiscountCampaign(
					new SqlDiscountRepository(connStr));
			// Again Creates new instance of repository per object requested
			var discountPolicy =
				new RepositoryBasketDiscountPolicy(
					new SqlDiscountRepository(connStr));

			return new HomeController(
				discountCampaign, discountPolicy);
		}
	}
}