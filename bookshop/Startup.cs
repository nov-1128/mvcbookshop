using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bookshop.Startup))]
namespace bookshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
