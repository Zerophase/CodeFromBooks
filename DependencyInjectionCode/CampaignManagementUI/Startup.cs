using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampaignManagementUI.Startup))]
namespace CampaignManagementUI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
