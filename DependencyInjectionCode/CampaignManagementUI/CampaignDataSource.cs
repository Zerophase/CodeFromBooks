using System.Collections.Generic;
using System.Web;
using CampaignPresentationLogic;

namespace CampaignManagementUI
{
	public class CampaignDataSource
	{
		private readonly CampaignPresenter presenter;

		// NOTE Container in ASP.NET Web Forms
		// Requires default constructor since ASP.NET cannot use parameterized constructors.
		public CampaignDataSource()
		{
			var container = (CampaignContainer) HttpContext.Current.
				Application["container"];
			this.presenter = container.ResolvePresenter();
		}

		// All calls of this class methods delegate the call to the presenter
		// Acts as a humble object, which wraps other classes to present them
		// to a frameworks API.
		public IEnumerable<CampaignItemPresenter> SelectAll()
		{
			return this.presenter.SelectAll();
		}

		public void Update(CampaignItemPresenter item)
		{
			this.presenter.Update(item);
		}
	}
}