using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Linterest.Startup))]
namespace Linterest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
