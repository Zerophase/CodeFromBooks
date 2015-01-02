using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcLifetime.Startup))]
namespace MvcLifetime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
