using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class LoginController : Controller
    {

        List<LoginUser> userList = new List<LoginUser>
        {
            new LoginUser
            {
                Account = "123",
                Password = "123",
                Role = "normal",
                Name = "Tony",
                IsDisable = false
            },
            new LoginUser
            {
                Account = "1234",
                Password = "1234",
                Role = "admin",
                Name = "Matt",
                IsDisable = false
            }
        };
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(LoginUser loginUser)
        {
            var user = (from a in userList
                        where a.Account == loginUser.Account
                        && a.Password == loginUser.Password
                        && a.IsDisable == false
                        select a).SingleOrDefault();

            if(user == null)
            {
                ViewData["ErrorMessage"] = "帳號與密碼有誤";
                return View();
            }
            else
            {
                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Account),
                            new Claim("FullName", user.Name),
                            new Claim(ClaimTypes.Role, user.Role.ToString()),
                            new Claim("LastChanged", DateTime.Now.ToString())
                        };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsRrincipal(claimsIdentity));
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDeny()
        {
            return View();
        }
    }
}
