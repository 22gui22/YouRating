using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YouRate.Startup))]
namespace YouRate
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
