using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEP6.Startup))]
namespace SEP6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
