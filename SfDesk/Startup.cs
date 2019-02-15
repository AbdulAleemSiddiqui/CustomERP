using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SfDesk.Startup))]
namespace SfDesk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
