using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TerminiDostave.Startup))]
namespace TerminiDostave
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
