using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEP6Film.Startup))]
namespace SEP6Film
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
