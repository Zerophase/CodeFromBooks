using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Baskets;

namespace BasketPowerShellLogic
{
    public class BasketManager
    {
	    private readonly IBasketService basketService;

	    public BasketManager(IBasketService basketService)
	    {
			if (basketService == null)
			{
				throw new ArgumentNullException("basketService");
			}

			this.basketService = basketService;
	    }

		public IEnumerable<BasketView> GetAllBaskets()
		{
			return from b in this.basketService.GetAllBaskets()
				   select new BasketView(b);
		}

		public void RemoveBasket(string owner)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}

			var p = new GenericPrincipal(new GenericIdentity(owner), null);
			this.basketService.Empty(p);
		}
    }
}
