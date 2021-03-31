using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using opentrek.Models;

namespace opentrek.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SetSessionString();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void SetSessionString()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                ViewData["CookieName"] = "Welcome, " + HttpContext.Session.GetString("UserName");
                ViewData["LoginButtonAction"] = "Logout";
            }
            else
            {
                ViewData["CookieName"] = "";
                ViewData["LoginButtonAction"] = "Login";
            }
        }
    }
}
