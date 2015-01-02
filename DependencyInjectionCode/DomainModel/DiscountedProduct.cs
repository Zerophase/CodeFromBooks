using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
	public class DiscountedProduct
	{
		private readonly string name;
		public string Name { get { return name; } }
		
		private readonly decimal unitPrice;
		public decimal UnitPrice { get { return unitPrice; } }

		public DiscountedProduct(string name, decimal unitPrice)
		{
			if(name == null)
				throw new ArgumentNullException("name");

			this.name = name;
			this.unitPrice = unitPrice;
		}
	}
}
