using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Examen_ToolsForEver.Models;
using Examen_ToolsForEver.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examen_ToolsForEver.Controllers
{
    //[Authorize]
    public class BasicController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly ApplicationDbContext _dbcontext;
        protected readonly RoleManager<IdentityRole> _roleManager;

        public BasicController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbcontext, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._dbcontext = dbcontext;
            this._roleManager = roleManager;
        }
    }
}
