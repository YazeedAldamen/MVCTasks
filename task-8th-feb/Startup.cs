using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(task_8th_feb.Startup))]
namespace task_8th_feb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
