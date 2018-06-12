using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC.ECommerce.Startup))]
namespace MVC.ECommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
