using System.Configuration;
using CampaignPresentationLogic;
using CommerceSqlDataAccess;
using DomainModel;

namespace CampaignManagementUI
{
	public class CampaignContainer
	{
		public CampaignPresenter ResolvePresenter()
		{
			string connectionString =
				ConfigurationManager.ConnectionStrings["CommerceObjectContext"].ConnectionString;
			CampaignRepository repository = new SqlCampaignRepository(connectionString);

			IPresentationMapper mapper = new PresentationMapper();

			return new CampaignPresenter(repository, mapper);
		}
	}
}