﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using opentrek.Data;
using opentrek.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace opentrek.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly OpenTrekContext _context;
        private UserModel _user = new UserModel();
        public const string SessionKeyName = "_Name";


        public AccountController(ILogger<AccountController> logger, OpenTrekContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel user)
        {
            if (user == null)
                return NotFound();

            // Search the database to find the first user where the email and password match
            _user = _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).First();

            HttpContext.Session.SetString(SessionKeyName, (_user.Id).ToString());

            return Redirect("Home");
        }

        public IActionResult Signup()
        {
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
                return Redirect("Index");
            }

            return View(user);
        }
    }
}
