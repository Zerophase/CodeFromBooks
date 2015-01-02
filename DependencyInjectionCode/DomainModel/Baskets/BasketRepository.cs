using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Baskets
{
	public abstract partial class BasketRepository
	{
		public abstract void AddToBasket(int productId, int quantity, IPrincipal user);

		public abstract void Empty(IPrincipal user);

		public abstract IEnumerable<Extent> GetBasketFor(IPrincipal user);
	}

	public abstract partial class BasketRepository
	{
		public abstract IEnumerable<Basket> GetAllBaskets();
	}
}
