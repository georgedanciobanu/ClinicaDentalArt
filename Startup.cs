using ClinicaDentalArt.DAL;
using ClinicaDentalArt.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(ClinicaDentalArt.Startup))]
namespace ClinicaDentalArt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        private void CreateRoles()
        {
            var _context = new ApplicationDbContext();

            //Add the User role if not exits
            if (!_context.Roles.Any(r => r.Name == "User"))
            {
                _context.Roles.Add(new IdentityRole("User"));
                _context.SaveChanges();
            }
        }
    }
}
