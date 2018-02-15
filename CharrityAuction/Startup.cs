using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CharrityAuction.Startup))]
namespace CharrityAuction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
