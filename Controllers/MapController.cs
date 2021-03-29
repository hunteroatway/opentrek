using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using opentrek.Models;
using opentrek.Data;
using Microsoft.AspNetCore.Http;

namespace opentrek.Controllers
{
    public class MapController : Controller
    {
        private readonly ILogger<MapController> _logger;
        private readonly OpenTrekContext _context;
        private LocationModel _location = new LocationModel();

        public MapController(ILogger<MapController> logger, OpenTrekContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("UserID") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            /*
             * Get the recommendation to update the model which will be passed to
             * the view to be displayed on the index page.
             */
            GetRecommendation(null);
            SetSessionString();

            return View(_location);
        }

        public string GetRecommendation(string country)
        {
            /* 
             * Search the database where the model and json provided country are the same
             * then return the recommendation to the function.
             */
            if (country != null)
            {
                _location = _context.Locations.Where(x => x.Country == country).FirstOrDefault();
            }

            return _location.Recommendation;
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