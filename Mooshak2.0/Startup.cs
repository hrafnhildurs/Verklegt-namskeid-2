using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mooshak2._0.Startup))]
namespace Mooshak2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
