using HeavenlyHome_Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeavenlyHomeApartments_WebMVC.Startup))]
namespace HeavenlyHomeApartments_WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        // In this method we will create default User roles and Admin user for login
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

            // In Startup I am creating first Admin Role and creating a default Admin User

            if (!roleManager.RoleExists("Admin"))
            {
                //Creating Admin Role

                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Creating a Admin who will maintain website

                var user = new ApplicationUser();
                user.UserName = "Shirisha";
                user.Email = "shirisha46@gmail.com";
                string userPassword = "Siriram@46";

                var checkUSer = userManager.Create(user, userPassword);

                if (checkUSer.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }

            }

            //Creating Manager Role

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            //Creating Resident Role
            if (!roleManager.RoleExists("Resident"))
            {
                var role = new IdentityRole();
                role.Name = "Resident";
                roleManager.Create(role);

            }

            //Creating Applicant Role

            if (!roleManager.RoleExists("Applicant"))
            {
                var role = new IdentityRole();
                role.Name = "Applicant";
                roleManager.Create(role);

            }

        }
    }
}
