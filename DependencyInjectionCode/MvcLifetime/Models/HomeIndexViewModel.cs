using System.Collections.Generic;
using Lifetime;

namespace MvcLifetime.Models
{
	public class HomeIndexViewModel
	{
		private readonly List<Product> products;

		public HomeIndexViewModel()
		{
			products = new List<Product>();
		}

		public IList<Product> Products
		{
			get { return products; }
		}
	}
}