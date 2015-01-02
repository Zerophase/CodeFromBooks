using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Baskets
{
	public partial interface IBasketService
	{
		void AddToBasket(int productId, int quantity, IPrincipal user);
		void Empty(IPrincipal user);
		Basket GetBasketFor(System.Security.Principal.IPrincipal user);
	}

	public partial interface IBasketService
	{
		IEnumerable<Basket> GetAllBaskets();
	}
}
