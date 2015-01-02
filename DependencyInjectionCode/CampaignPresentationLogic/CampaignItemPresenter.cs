using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampaignPresentationLogic
{
	public class CampaignItemPresenter
	{
		public decimal? DiscountPrice { get; set; }

		public int Id { get; set; }

		public bool IsFeatured { get; set; }

		public string ProductName { get; set; }

		public decimal UnitPrice { get; set; }
	}
}
