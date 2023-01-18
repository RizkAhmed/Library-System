using CoreIdentity.Models;
using CoreIdentity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentity.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContect _context;
        private readonly UserManager<IdentityUser> _userManger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountsController(AppDbContect context, UserManager<IdentityUser>userManger,SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManger = userManger;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LogViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.Email.Split('@')[0],
                    Email = model.Email,
                };
                var result =await _userManger.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, true); 
                    return RedirectToAction(nameof(Index),"Home");
                }
                else
                {
                    foreach(var erorr in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty,erorr.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
