using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifetime
{
	public class SqlDiscountRepository : DiscountRepository
	{
		private readonly List<Product> products;

		public SqlDiscountRepository(string connString)
		{
			products = new List<Product>();	
		}

		public override IList<Product> Products
		{
			get { return products; }
		}

		public override IEnumerable<Product> GetDiscountedProducts()
		{
			return products;
		}
	}
}
