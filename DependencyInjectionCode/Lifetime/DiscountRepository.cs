using System.Collections;
using System.Collections.Generic;

namespace Lifetime
{
	public abstract class DiscountRepository
	{
		public abstract IList<Product> Products { get; }
		public abstract IEnumerable<Product> GetDiscountedProducts();
	}
}