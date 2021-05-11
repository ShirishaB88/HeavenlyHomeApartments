using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeavenlyHomeApartments_WebMVC.Startup))]
namespace HeavenlyHomeApartments_WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
