using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuitoText_1._0.Startup))]
namespace QuitoText_1._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
