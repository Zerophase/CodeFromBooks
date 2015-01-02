using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceSqlDataAccess
{
	public class SqlDiscountRepository : DomainModel.DiscountRepository
	{
		private readonly CommerceObjectContext context;

        public SqlDiscountRepository(string connString)
        {
            this.context = new CommerceObjectContext(connString);
        }

		public override IEnumerable<DomainModel.Product> GetDiscountedProducts()
		{
			return (from p in this.context.Products
				where p.DiscountedUnitPrice.HasValue
				select p).AsEnumerable().Select(p => p.ToDiscountedProduct());
		}
	}
}
