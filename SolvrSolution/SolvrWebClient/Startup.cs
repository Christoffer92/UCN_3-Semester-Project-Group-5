using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SolvrWebClient.Startup))]
namespace SolvrWebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
