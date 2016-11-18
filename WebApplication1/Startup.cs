using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BashPosts.Startup))]
namespace BashPosts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
