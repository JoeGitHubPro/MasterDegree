using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MasterDegree.UserDefined;
using MasterDegree.Models;

namespace MasterDegree.UserDefined
{
    public static class UsersStartup
    {
        public static void createRolesandUsers()
        {

            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // In Startup iam creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists(MasterDegree.UserDefined.RoleName.Admin))
            {
             

                // first we create Admin rool
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = MasterDegree.UserDefined.RoleName.Admin;
                roleManager.Create(role);
                //Here we create a Admin super user who will maintain the website 
                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "Admin@mail.com";


                string userPWD = "7nJ4oq7@f*Dg";

                var chkUser = UserManager.Create(user, userPWD);
                //add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var resultl = UserManager.AddToRole(user.Id, MasterDegree.UserDefined.RoleName.Admin);
                }
            }


            // creating Creating Trainer role

            if (!roleManager.RoleExists(MasterDegree.UserDefined.RoleName.User))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = MasterDegree.UserDefined.RoleName.User;
                roleManager.Create(role);
            }
            // creating Creating Manager role 
            if (!roleManager.RoleExists(MasterDegree.UserDefined.RoleName.Manger))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = MasterDegree.UserDefined.RoleName.Manger;
                roleManager.Create(role);

            }
        }
    }
}