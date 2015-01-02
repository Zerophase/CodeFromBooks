using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace CommerceSqlDataAccess
{
	public partial class BasketLine
	{
		internal Extent NOTEmainProductExtent()
		{
			var product = this.Product.NOTEmainProduct();
			var pe = new Extent(product);
			pe.Quantity = this.Quantity;
			pe.Updated = new DateTimeOffset(DateTime.SpecifyKind(this.UtcUpdated, DateTimeKind.Utc));

			return pe;
		}
	}
}
