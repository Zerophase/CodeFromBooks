using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Baskets;

namespace BasketPowerShellLogic
{
	public class BasketView
	{
		private readonly string owner;
		private readonly DateTimeOffset lastUpdated;
		private readonly decimal total;

		public BasketView(Basket basket)
		{
			if (basket == null)
			{
				throw new ArgumentNullException("basket");
			}

			this.owner = basket.Owner.Identity.Name;
			this.lastUpdated = basket.Updated;
			this.total = (from e in basket.Contents
						  select e.Total.Amount).Sum();
		}

		public DateTimeOffset LastUpdated
		{
			get { return this.lastUpdated; }
		}

		public string Owner
		{
			get { return this.owner; }
		}

		public decimal Total
		{
			get { return this.total; }
		}
	}
}
