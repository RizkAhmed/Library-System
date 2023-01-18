using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_ExternalAuth.Startup))]
namespace MVC_ExternalAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
