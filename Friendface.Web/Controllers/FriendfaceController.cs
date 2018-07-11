using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Friendface.Core;

namespace Friendface.Web.Controllers
{
    public class FriendfaceController : Controller
    {
        private readonly FriendfaceService friendfaceService;

        public FriendfaceController(FriendfaceService friendfaceService)
        {
            this.friendfaceService = friendfaceService;
        }


        [Route("[action]")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IActionResult Friends()
        {
            var friends = friendfaceService.ShowList();

            return View(friends);
        }

        [HttpGet("[action]")]
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

        [HttpGet("[action]")]
        public IActionResult Create()
        {
            var friend = new Core.Friendface();
            return View(friend);
        }

        [HttpPost("[action]")]
        public IActionResult Create(Core.Friendface friend)
        {
            if (!ModelState.IsValid)
            {
                return View(friend);
            }
            else
            {
                friendfaceService.Create(friend.Name, friend.Birthday, friend.Description);
                return RedirectToAction("Index");
            }
        }
    }
}