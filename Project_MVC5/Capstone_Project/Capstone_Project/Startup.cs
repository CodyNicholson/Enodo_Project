using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capstone_Project.Startup))]
namespace Capstone_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
