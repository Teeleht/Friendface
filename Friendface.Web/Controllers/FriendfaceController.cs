using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Friendface.Core;
using Friendface.Web.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Friendface.Web.Controllers
{
// logout, login nupud, nimi sisselogimisel, home'i tagasi
    [Authorize]
    public class FriendfaceController : Controller
    {
        private readonly FriendfaceService friendfaceService;

        public FriendfaceController(FriendfaceService friendfaceService)
        {
            this.friendfaceService = friendfaceService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Friends()
        {
            var friends = friendfaceService.ShowList();

            return View(friends);
        }

        [HttpGet]
        public IActionResult Details(int friendId)
        {
            var friend = friendfaceService.ShowList().First(x => x.Id == friendId);
            if (friend != null)
            {
                return View(friend);
            }
            else
            {
                throw new Exception("There's no friend with that ID.");
            }
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            var user = new Core.Domain.User();
            return View(user);
        }

        [HttpPost]
        public IActionResult RegisterUser(Core.Domain.User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                friendfaceService.CreateUser(user.Username, user.Password, user.Birthday, user.Description, user.Address, user.Email, user.Gender);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (login.Username == "Teele" && login.Password == "111")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. Required when setting the 
                    // ExpireTimeSpan option of CookieAuthenticationOptions 
                    // set with AddCookie. Also required when setting 
                    // ExpiresUtc.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

                return RedirectToAction("Index");
            }
            else
            {
                return View(login);
            }

        }

        /*[HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(RegistrationViewModel register)
        {

            return View();
        }*/
    }
}