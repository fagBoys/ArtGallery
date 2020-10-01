using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //Login action
            return View();
        }

        public IActionResult Register()
        {
            //Register action
            return View();
        }

    }
}
