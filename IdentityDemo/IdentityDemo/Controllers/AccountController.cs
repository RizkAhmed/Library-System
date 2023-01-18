using IdentityDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace IdentityDemo.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                //add user to database
                var context = new AppDbContext();
                context.Users.Add(user);
                context.SaveChanges();

                //create identity

                var userIdentity = new ClaimsIdentity(
                    new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim("Name",user.Name),
                        new Claim("Password",user.Password)
                    }, "AppCookie");
                Request.GetOwinContext().Authentication.SignIn(userIdentity);
                return RedirectToAction("Index", "Home");

            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var context = new AppDbContext();
            var LoggedUser = context.Users.FirstOrDefault
                (u => u.Email == user.Email && u.Password == user.Password);

            if(LoggedUser!= null)
            {
                var SignInIdentity = new ClaimsIdentity(
                    new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,LoggedUser.Email),
                        new Claim("Password",LoggedUser.Password)
                    }, "AppCookie");
                Request.GetOwinContext().Authentication.SignIn(SignInIdentity);
                return RedirectToAction("Index","Home");


            }
            return View();
        }
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppCookie");
            return RedirectToAction("Login");
        }
    }
}