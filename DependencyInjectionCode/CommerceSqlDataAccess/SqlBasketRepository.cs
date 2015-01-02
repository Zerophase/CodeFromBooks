using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Principal;
using DomainModel.Baskets;

namespace CommerceSqlDataAccess
{
	public partial class SqlBasketRepository : DomainModel.Baskets.BasketRepository
	{
		private readonly CommerceObjectContext context;

		public SqlBasketRepository(string connString)
		{
			this.context =
				new CommerceObjectContext(connString);
		}

		public override void AddToBasket(int productId, int quantity, System.Security.Principal.IPrincipal user)
		{
			var basketLine = (from bl in this.context.BasketLines.Include("User")
							  where bl.ProductId == productId
							  && bl.User.LoweredUserName == user.Identity.Name.ToLower()
							  select bl).FirstOrDefault();
			if (basketLine == null)
			{
				basketLine = new BasketLine();
				basketLine.User = (from u in this.context.Users
								   where u.LoweredUserName == user.Identity.Name.ToLower()
								   select u).First();
				basketLine.Product = (from p in this.context.Products
									  where p.ProductId == productId
									  select p).First();

				this.context.AddToBasketLines(basketLine);
			}
			basketLine.Quantity += quantity;
			basketLine.UtcUpdated = DateTime.UtcNow;
			this.context.SaveChanges();
		}

		public override void Empty(System.Security.Principal.IPrincipal user)
		{
			var basketLines = from bl in this.context.BasketLines.Include("User")
							  where bl.User.LoweredUserName == user.Identity.Name.ToLower()
							  select bl;
			foreach (var bl in basketLines)
			{
				this.context.DeleteObject(bl);
			}
			this.context.SaveChanges();
		}

		public override IEnumerable<DomainModel.Extent> GetBasketFor(System.Security.Principal.IPrincipal user)
		{
			return (from bl in this.context.BasketLines.Include("Product").Include("User")
					where bl.User.LoweredUserName == user.Identity.Name.ToLower()
					select bl).AsEnumerable().Select(bl => bl.NOTEmainProductExtent());
		}

	}

	public partial class SqlBasketRepository : DomainModel.Baskets.BasketRepository
	{

		public override IEnumerable<DomainModel.Baskets.Basket> GetAllBaskets()
		{
			var users = (from u in this.context.Users.Include("BasketLines.Product")
						 where u.BasketLines.Any()
						 select u).AsEnumerable();
			foreach (var u in users)
			{
				var b = new Basket(new GenericPrincipal(new GenericIdentity(u.LoweredUserName), null));
				foreach (var bl in u.BasketLines)
				{
					b.Contents.Add(bl.NOTEmainProductExtent());
				}
				yield return b;
			}
		}
	}
}