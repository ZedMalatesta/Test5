using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project5E.Startup))]
namespace Project5E
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
