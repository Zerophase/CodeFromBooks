using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModel;
using DomainModel.Providers;
using UserInterface.Models;

namespace UserInterface.Controllers
{
	public class HomeController : Controller
	{
		private readonly ProductRepository repository;
		private readonly CurrencyProvider currencyProvider;
		private CurrencyProfileService currencyProfileService;
		private bool currencyProfileServiceLocked;

		public HomeController(ProductRepository repository, CurrencyProvider currencyProvider)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			if (currencyProvider == null)
			{
				throw new ArgumentNullException("currencyProvider");
			}

			this.repository = repository;
			this.currencyProvider = currencyProvider;
		}

		public CurrencyProfileService CurrencyProfileService
		{
			get
			{
				if (this.currencyProfileService == null)
				{
					this.CurrencyProfileService = new DefaultCurrencyProfileService(this.HttpContext);
				}
				return this.currencyProfileService;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (this.currencyProfileServiceLocked)
				{
					throw new InvalidOperationException();
				}
				this.currencyProfileService = value;
				this.currencyProfileServiceLocked = true;
			}
		}

		public ActionResult Index()
		{
			var currencyCode = this.CurrencyProfileService.GetCurrencyCode();
			var currency = this.currencyProvider.GetCurrency(currencyCode);

			var productService =
				new ProductService(this.repository);

			var vm = new FeaturedProductsViewModel();

			var products =
				productService.GetFeaturedProducts(this.User);

			foreach (var product in products)
			{
				var productVM = new ProductViewModel(product.ConvertTo(currency));
				vm.Products.Add(productVM);
			}

			return this.View(vm);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}