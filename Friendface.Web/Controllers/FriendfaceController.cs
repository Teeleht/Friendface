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
using Friendface.Core.Domain;
using Microsoft.AspNetCore.Http;

namespace Friendface.Web.Controllers
{
    // TODO: chat esilehele: kell, autor ja message
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
            var user = friendfaceService.GetUser(User.Identity.Name);
            var friendships = friendfaceService.ShowFriendships().Where(x => x.UserA.Id == user.Id || x.UserB.Id == user.Id);
            var posts = friendfaceService.GetPosts().Where(x => x.AuthorId == user.Id);

            var model = new IndexModel
            {
                User = user,
                Friendships = friendships,
                Posts = posts,
            };

            return View(model);
        }

        // all users
        [HttpGet]
        public IActionResult Friends()
        {
            var friends = friendfaceService.ShowList();

            return View(friends);
        }

        [HttpGet]
        public IActionResult Details(int userId)
        {
            var friend = friendfaceService.GetUser(userId);
            var user = friendfaceService.GetUser(User.Identity.Name);
            var posts = friendfaceService.GetPosts().Where(x => x.AuthorId == userId);

            var areFriends = friendfaceService.AreFriends(user.Id, friend.Id);
            var isMe = false;

            if (friend == user)
            {
                isMe = true;
            }

            var model = new DetailModel
            {
                IsFriend = areFriends,
                User = friend,
                IsMe = isMe,
                Posts = posts,
            };
            return View(model);

        }

        // added friends
        [HttpGet]
        public IActionResult AddedFriends()
        {
            var friendships = friendfaceService.ShowFriendships();
            return View(friendships);
        }

        // create new friendship
        [HttpPost]
        public IActionResult CreateFriendship(DetailModel model)
        {
            //friendfaceService.ClearFriends(); // clear database
            //friendfaceService.ClearUsers();
            var userA = friendfaceService.GetUser(User.Identity.Name);
            var userB = friendfaceService.GetUser(model.User.Id);
                          
            friendfaceService.CreateFriendship(userA, userB, DateTime.Now);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult DeleteFriendship(DetailModel model)
        {
            var userA = friendfaceService.GetUser(User.Identity.Name);
            var userB = friendfaceService.GetUser(model.User.Id);

            friendfaceService.DeleteFriendship(userA, userB);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChangeProfile()
        {
            var user = friendfaceService.GetUser(User.Identity.Name);
            var model = new ChangeProfileModel
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Address = user.Address,
                Birthday = user.Birthday,
                Description = user.Description,
                Gender = user.Gender,

        };
            return View(model);
        }

        [HttpPost]
        public IActionResult ChangeProfile(ChangeProfileModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                friendfaceService.ChangeProfile(model.Id, model.Username, model.Password, model.Birthday, model.Description, model.Address, model.Email, model.Gender);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            var post = new Post();
            return View(post);
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            else
            {
                var author = friendfaceService.GetUser(User.Identity.Name);
                friendfaceService.CreatePost(author.Id, post.Content, post.Title, DateTime.Now);
                return RedirectToAction("Index");
            }
        }

        // create new user
        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterUser()
        {
            var user = new User();
            return View(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegisterUser(User user)
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
        public async Task<IActionResult> Login(RegistrationViewModel login)
        {
            User user = friendfaceService.ShowList().First(x => x.Username == login.Username && x.Password == login.Password);

            if (user != null)
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

        [HttpGet]
        public async Task<IActionResult> Logout()
        {           
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        
    }
}