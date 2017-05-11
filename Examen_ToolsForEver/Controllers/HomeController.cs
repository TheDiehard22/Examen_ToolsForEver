using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_ToolsForEver.Data;
using Examen_ToolsForEver.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Examen_ToolsForEver.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Examen_ToolsForEver.Controllers
{
    public class HomeController : BasicController
    {
        private readonly SignInManager<ApplicationUser> _SignInManager;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbcontext, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager) 
            : base(userManager, dbcontext, roleManager)
        {
            this._SignInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginModel, string returnURL = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _SignInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index));
                }
                else
                {
                    return View(loginModel);
                }
            }

            //If the user gets here, he couldnt login
            return View(loginModel);
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
