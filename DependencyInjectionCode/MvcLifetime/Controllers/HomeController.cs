using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lifetime;
using MvcLifetime.Models;

namespace MvcLifetime.Controllers
{
	public class HomeController : Controller
	{
		private readonly DiscountCampaign campaign;
		private readonly BasketDiscountPolicy policy;

		public HomeController(DiscountCampaign campaign,
			BasketDiscountPolicy policy)
		{
			if (campaign == null)
			{
				throw new ArgumentNullException("campaign");
			}
			if (policy == null)
			{
				throw new ArgumentNullException("policy");
			}

			this.campaign = campaign;
			this.policy = policy;
		}

		public DiscountCampaign Campaign
		{
			get { return this.campaign; ; }
		}

		public BasketDiscountPolicy Policy
		{
			get { return this.policy; }
		}

		public ActionResult Index()
		{
			this.campaign.AddProduct(new Product { Name = "Success" });

			var vm = new HomeIndexViewModel();

			var products = this.policy.GetDiscountedProducts();
			foreach (var p in products)
			{
				vm.Products.Add(p);
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