using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication6.Startup))]
namespace WebApplication6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
