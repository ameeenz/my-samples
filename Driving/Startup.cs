using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Driving.Startup))]
namespace Driving
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
