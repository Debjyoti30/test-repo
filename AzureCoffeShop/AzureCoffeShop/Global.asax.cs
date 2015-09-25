using core.Blob;
using core.Table.Service;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AzureCoffeShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            new CoffeeService().Initialize();
            new BlobService().Initialize();
        }
    }
}
