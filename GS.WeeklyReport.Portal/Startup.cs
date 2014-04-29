using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GS.WeeklyReport.Portal.Startup))]
namespace GS.WeeklyReport.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
