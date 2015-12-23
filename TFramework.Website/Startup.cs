using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TFramework.Website.Startup))]
namespace TFramework.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
