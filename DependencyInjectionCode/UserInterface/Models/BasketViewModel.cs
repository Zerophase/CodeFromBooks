using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel.Baskets;

namespace UserInterface.Models
{
	public class BasketViewModel
	{
		private readonly Basket basket;

		public BasketViewModel(Basket basket)
		{
			if (basket == null)
			{
				throw new ArgumentNullException("basket");
			}

			this.basket = basket;
		}

		public IEnumerable<string> Contents
		{
			get
			{
				return from e in this.basket.Contents
					   select string.Format("{0} {1}: {2:C}", e.Quantity, e.Product.Name, e.Total);
			}
		}
	}
}