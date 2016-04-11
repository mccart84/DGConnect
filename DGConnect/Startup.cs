using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DGConnect.Startup))]
namespace DGConnect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
