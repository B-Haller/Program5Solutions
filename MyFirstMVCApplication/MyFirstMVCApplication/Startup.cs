using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFirstMVCApplication.Startup))]
namespace MyFirstMVCApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
