using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecetAgro_WS.Startup))]
namespace RecetAgro_WS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
