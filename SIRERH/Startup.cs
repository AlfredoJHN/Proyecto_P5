using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIRERH.Startup))]
namespace SIRERH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
