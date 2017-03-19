using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthWindWebAPI.Startup))]
namespace NorthWindWebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
