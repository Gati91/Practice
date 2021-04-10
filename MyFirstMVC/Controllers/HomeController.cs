using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstMVC.Models;
using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyFirstMVC.Controllers
{
    

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration configuration { get; }

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            configuration = config;
        }

        public IActionResult Index()
        {
            TempData["Date"] = DateTime.Now.ToString();
            TempData["Name"] = "Gautam";
            SelfDetails selfDetails = new SelfDetails()
            {
                ContactNum = "12323432435",
                DateofBirth = DateTime.Now,
                domainAreas = GenerateDomainAreas()
            };
            return View(selfDetails);
        }

        public List<DomainAreas> GenerateDomainAreas()
        {
            var lst = new List<DomainAreas>();
            for (int i = 0; i <= 1; i++)
            {
                DomainAreas domainAreas = new DomainAreas()
                {
                    DomainID = i,
                    DomainName = i == 0? "C#" : "ASP.Net"
                };
                lst.Add(domainAreas);                
            }
            return lst;
        }

        //public List<SelectListItem> selectListItems()
        //{
        //    var x = new List<SelectListItem>();
        //    foreach (var item in GenerateDomainAreas())
        //    {
        //        x.Add(new SelectListItem
        //        {
        //            Text = item.Value,
        //            Value = item.Key.ToString()
        //        });
        //    }
        //    return x;
        //}

        public IActionResult AsycGautam()
        {

            //var x = TempData["Date"];
            //var y = TempData["Name"];
            TempData["ConnectionString"] = configuration.GetConnectionString("DefaultConnection");
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
