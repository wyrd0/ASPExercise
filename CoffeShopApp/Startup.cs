using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoffeShopApp.Startup))]
namespace CoffeShopApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
