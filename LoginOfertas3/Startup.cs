using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginOfertas3.Startup))]
namespace LoginOfertas3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
