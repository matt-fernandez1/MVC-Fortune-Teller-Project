using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fortune_teller_mvc.Startup))]
namespace fortune_teller_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
