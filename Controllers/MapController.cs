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

namespace opentrek.Controllers
{
    public class MapController : Controller
    {
        private readonly ILogger<MapController> _logger;
        private readonly OpenTrekContext _context;

        public MapController(ILogger<MapController> logger, OpenTrekContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult Index(string country)
        {
            LocationModel location = _context.Locations.Where(x => x.Country == country).FirstOrDefault();
            
            if (country != null)
                Console.WriteLine(location.Recommendation);

            return View(location);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}