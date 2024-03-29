﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstMVC.Models;
using System;
using System.Diagnostics;

namespace MyFirstMVC.Controllers
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
            TempData["Date"] = DateTime.Now.ToString();
            TempData["Name"] = "Gautam";
            return View();
        }

        public IActionResult AsycGautam()
        {
            //var x = TempData["Date"];
            //var y = TempData["Name"];
            return RedirectToAction("Index", "Test");
        }

        public IActionResult Privacy()
        {
            //var x = TempData["Date"];
            //var y = TempData["Name"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
