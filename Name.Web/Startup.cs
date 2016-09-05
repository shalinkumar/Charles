using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Name.Web.Startup))]
namespace Name.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
