using System;

namespace Lifetime
{
	public class DiscountCampaign
	{
		private readonly DiscountRepository repository;

		public DiscountCampaign(DiscountRepository repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}

			this.repository = repository;
		}

		public DiscountRepository Repository
		{
			get { return this.repository; }
		}

		public virtual void AddProduct(Product product)
		{
			this.repository.Products.Add(product);
		}
	}
}