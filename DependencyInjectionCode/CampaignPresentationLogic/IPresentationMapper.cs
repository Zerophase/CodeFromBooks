using System.Collections;
using System.Collections.Generic;
using DomainModel;

namespace CampaignPresentationLogic
{
	public interface IPresentationMapper
	{
		CampaignItemPresenter Map(CampaignItem item);
		IEnumerable<CampaignItemPresenter> Map(IEnumerable<CampaignItem> items);
		CampaignItem Map(CampaignItemPresenter presenter);
	}
}