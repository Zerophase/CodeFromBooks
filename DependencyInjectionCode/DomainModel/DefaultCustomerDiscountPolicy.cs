using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
	public class DefaultCustomerDiscountPolicy
	{
		public Product Apply(Product product, IPrincipal customer)
		{
			var discount = customer.IsInRole("PreferredCustomer") ? .95m : 1;
			return product.WithUnitPrice(product.UnitPrice.Multiply(discount));
		}
	}
}
