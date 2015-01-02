using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DomainModel;
using DomainModel.Baskets;
using DomainModel.Providers;
using UserInterface.Models;

namespace UserInterface.Controllers
{
	public class BasketController : Controller
	{
		private readonly IBasketService basketService;
		private readonly CurrencyProvider currencyProvider;

		public BasketController(IBasketService basketService,
			CurrencyProvider currencyProvider)
		{
			if (basketService == null)
			{
				throw new ArgumentNullException("basketService");
			}
			if (currencyProvider == null)
			{
				throw new ArgumentNullException("currencyProvider");
			}

			this.basketService = basketService;
			this.currencyProvider = currencyProvider;
		}

		private CurrencyProfileService currencyProfileService;
		// NOTE Property Injection
		// Makes sure the property is assigined when used, and can't be set again later.
		// This example ignores implementation with thread safety
		public CurrencyProfileService CurrencyProfileService
		{
			get
			{
				if (this.currencyProfileService == null)
				{
					this.CurrencyProfileService =
						new DefaultCurrencyProfileService(
							this.HttpContext);
				}
				return this.currencyProfileService;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (this.currencyProfileService != null)
				{
					throw new InvalidOperationException();
				}
				this.currencyProfileService = value;
			}
		}

		public ActionResult Index()
		{
			var currencyCode = CurrencyProfileService.GetCurrencyCode();
			var currency = currencyProvider.GetCurrency(currencyCode);

			var basket = basketService.GetBasketFor(User).ConvertTo(currency);
			if (basket.Contents.Count == 0)
			{
				return View("Empty");
			}
			var vm = new BasketViewModel(basket);
			return View(vm);
		}
	}
}