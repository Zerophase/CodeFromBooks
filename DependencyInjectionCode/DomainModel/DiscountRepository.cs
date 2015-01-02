using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
	public abstract class DiscountRepository
	{
		public abstract IEnumerable<Product> GetDiscountedProducts();
	}
}
