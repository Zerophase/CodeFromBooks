using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasketPowerShellLogic;
using CommerceSqlDataAccess;
using DomainModel;
using DomainModel.Baskets;

namespace BasketPowerShell
{
	// NOTE Power Shell uses a static internal Container
	// as a work around for Power Shells design
	// keeping everything internal prevents it from being used outside,
	// of powerShell functions such as BasketManager
	// This protects us from making mistakes.
    internal static class BasketContainer
    {
		private const string connectionString = "metadata=res://*/CommerceModel.csdl|res://*/CommerceModel.ssdl|res://*/CommerceModel.msl;provider=System.Data.SqlClient;provider connection string=\"Data Source=.;Initial Catalog=ComplexCommerce;Integrated Security=True;MultipleActiveResultSets=True\"";

	    internal static BasketManager ResolveManager()
	    {
			BasketRepository basketRepository = 
				new SqlBasketRepository(BasketContainer.connectionString);
			DiscountRepository discountRepository =
				new SqlDiscountRepository(BasketContainer.connectionString);
		    
			BasketDiscountPolicy discountPolicy = 
				new RepositoryBasketDiscountPolicy(discountRepository);

			IBasketService basketService = 
				new BasketService(basketRepository, discountPolicy);

			return new BasketManager(basketService);
	    }
    }
}
