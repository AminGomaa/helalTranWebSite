﻿using Helalzahbi_Trans.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Helalzahbi_Trans.Startup))]
namespace Helalzahbi_Trans
{
   
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // CreateDefaultRolesAndUsers();
        }
        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Khalid";
                user.Email = "Khalid_essaadani@hotmail.fr";
                var Check = userManager.Create(user, "Kh@l!d123");
                if (Check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admins");
                }
            }
        }
    }
}
