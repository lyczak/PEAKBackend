using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PEAKBackend.Startup))]
namespace PEAKBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
