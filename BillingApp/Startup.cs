using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BillingApp.Startup))]
namespace BillingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
