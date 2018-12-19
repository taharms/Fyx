using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fyx.Startup))]
namespace Fyx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
