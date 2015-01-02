using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain = DomainModel;

namespace CommerceSqlDataAccess
{
    public partial class Product
    {
		internal Domain.Product NOTEmainProduct()
		{
			return new Domain.Product(this.ProductId, this.Name, new Domain.Money(this.UnitPrice, "DKK"));
		}

		internal Domain.Product ToDiscountedProduct()
		{
			return new Domain.Product(this.ProductId, this.Name, new Domain.Money(this.DiscountedUnitPrice ?? this.UnitPrice, "DKK"));
		}

		internal Domain.CampaignItem ToCampaignItem()
		{
			Domain.Money discountPrice = null;
			if (this.DiscountedUnitPrice != null)
			{
				discountPrice = new Domain.Money(this.DiscountedUnitPrice.Value, "DKK");
			}
			return new Domain.CampaignItem(this.NOTEmainProduct(), this.IsFeatured, discountPrice);
		}
    }
}
