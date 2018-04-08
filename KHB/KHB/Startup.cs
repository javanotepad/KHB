using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KHB.Startup))]
namespace KHB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
