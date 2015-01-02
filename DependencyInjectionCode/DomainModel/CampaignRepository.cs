using System.Collections;
using System.Collections.Generic;

namespace DomainModel
{
	public abstract class CampaignRepository
	{
		public abstract IEnumerable<CampaignItem> SelectAll();
		public abstract void Update(CampaignItem item);
	}
}