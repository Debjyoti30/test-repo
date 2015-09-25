using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureCoffeShop.Startup))]
namespace AzureCoffeShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
