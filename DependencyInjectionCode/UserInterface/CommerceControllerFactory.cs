using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CommerceSqlDataAccess;
using DomainModel;
using DomainModel.Baskets;
using DomainModel.Providers;
using UserInterface.Controllers;

namespace UserInterface
{
	// NOTE Containers in MVC
	// Overidede GetControllerInstance in DefaultControllerFactory
	// to arrange dependencies.
	public class CommerceControllerFactory : DefaultControllerFactory
	{
		protected override IController GetControllerInstance(
			RequestContext requestContext, Type controllerType)
		{
			// Creates the dependencies
			string connectionString =
				ConfigurationManager.ConnectionStrings
					["CommerceObjectContext"].ConnectionString;

			var productRepository =
				new SqlProductRepository(connectionString);
			var basketRepository =
				new SqlBasketRepository(connectionString);
			var discountRepository =
				new SqlDiscountRepository(connectionString);

			var discountPolicy =
				new RepositoryBasketDiscountPolicy(discountRepository);

			var basketService =
				new BasketService(basketRepository, discountPolicy);

			var currencyProvider = new CachingCurrencyProvider(
				new SqlCurrencyProvider(connectionString),
				TimeSpan.FromHours(1));

			// returns when the appropriate controller is found
			if (controllerType == typeof(BasketController))
			{
				return new BasketController(
					basketService, currencyProvider);
			}
			if (controllerType == typeof(HomeController))
			{
				return new HomeController(
					productRepository, currencyProvider);
			}

			// handles types not specifically requested for by using their default constructor.
			// This uses bastard injection, and should be avoided in your own code base when possible
			return base.GetControllerInstance(requestContext, controllerType);
		}
	}
}