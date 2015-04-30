using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleCrudCodeFirst.Startup))]
namespace SimpleCrudCodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
