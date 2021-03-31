using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using opentrek.Data;
using opentrek.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace opentrek.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly OpenTrekContext _context;
        private UserModel _user = new UserModel();
        public const string SessionKeyID = "UserID";
        public const string SessionKeyName = "UserName";

        public AccountController(ILogger<AccountController> logger, OpenTrekContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Login()
        {
            SetSessionString();

            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            if (user == null)
                return NotFound();

            // Search the database to find the first user where the email and password match
            _user = _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).First();

            // Set session cookies
            HttpContext.Session.SetString(SessionKeyID, _user.Id.ToString());
            HttpContext.Session.SetString(SessionKeyName, _user.FirstName);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionKeyID);
            HttpContext.Session.Remove(SessionKeyName);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Signup()
        {
            SetSessionString();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(UserModel user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return Redirect("Login");
            }

            return View(user);
        }
        
        public void SetSessionString()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                ViewData["CookieName"] = "Welcome, " + HttpContext.Session.GetString("UserName");
                ViewData["LoginButtonAction"] = "Logout";
                ViewData["CurrentUser"] = HttpContext.Session.GetString("UserID");
            }
            else
            {
                ViewData["CookieName"] = "";
                ViewData["LoginButtonAction"] = "Login";
            }
        }

        private bool UserModelExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
