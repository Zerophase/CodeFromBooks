using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel;

namespace UserInterface.Models
{
	public class ProductViewModel
	{
		private readonly int id;

		public int Id
		{
			get { return id; }
		}
		public string Name { get; set; }

		public Money UnitPrice { get; set; }

		public string SummaryText
		{
			get { return string.Format("{0} ({1:c}", this.Name, this.UnitPrice); }
		}

		public ProductViewModel(Product product)
		{
			this.id = product.Id;
			this.Name = product.Name;
			this.UnitPrice = product.UnitPrice;
		}
	}
}