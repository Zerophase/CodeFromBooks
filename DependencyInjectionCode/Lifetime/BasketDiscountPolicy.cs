using System.Collections;
using System.Collections.Generic;

namespace Lifetime
{
	public abstract class BasketDiscountPolicy
	{
		public abstract IEnumerable<Product> GetDiscountedProducts();
	}
}