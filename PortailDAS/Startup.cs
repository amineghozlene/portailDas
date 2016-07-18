using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortailDAS.Startup))]
namespace PortailDAS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
