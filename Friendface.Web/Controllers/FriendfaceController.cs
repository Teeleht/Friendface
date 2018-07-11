using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult ProfileDetails()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}