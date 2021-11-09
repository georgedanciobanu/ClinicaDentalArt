using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClinicaDentalArt.Startup))]
namespace ClinicaDentalArt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
