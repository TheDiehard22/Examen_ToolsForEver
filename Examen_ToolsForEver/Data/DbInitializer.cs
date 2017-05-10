using Examen_ToolsForEver.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_ToolsForEver.Data
{
    public class DbInitializer
    {
        protected ApplicationDbContext _dbcontext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DbInitializer(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this._dbcontext = dbContext;
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        public void RolesAreSeeded()
        {
            if (!_dbcontext.UserRoles.Any())
            {
                SeedUserRoles();
            }
        }

        public void AdminIsSeeded()
        {
            if (!_dbcontext.Users.Any())
            {
                SeedAdmin();
            }
        }

        private DbInitializer SeedAdmin()
        {
            var admin = new ApplicationUser()
            {
                UserName = "Admin",
                Email = "admin@toolsforever.nl",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(admin, "Admin123!");

            admin.PasswordHash = hashed;

            var userStore = new UserStore<ApplicationUser>(_dbcontext);
            userStore.CreateAsync(admin);

            _userManager.AddToRoleAsync(admin, "Administrator");

            return this;
        }

        private DbInitializer SeedUserRoles()
        {
            _roleManager.CreateAsync(new IdentityRole("Member"));
            _roleManager.CreateAsync(new IdentityRole("Administrator"));

            return this;
        }
    }
}
