using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MyFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyFirstMVC.Mapper;
using Newtonsoft.Json;

namespace MyFirstMVC.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string str = TempData["ConnectionString"] as string;
            TempData.Keep("ConnectionString");
            //var model = selectListItems();
            var x = new SelfDetails();
            x.domainAreas = GenerateDomainAreas();
            x.IsMale = true;
            x.HighPriorityReason = "true";
            return View(x);
        }
        [HttpPost]
        public string BindPersonValues() 
        {
            string constr = TempData.Peek("ConnectionString") as string;
            ModelMap modelMap = new ModelMap();
            var model = modelMap.MapPersonDetails(constr);
            string x = JsonConvert.SerializeObject(model);
            return  x;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<DomainAreas> GenerateDomainAreas()
        {
            var lst = new List<DomainAreas>();
            for (int i = 0; i <= 1; i++)
            {
                DomainAreas domainAreas = new DomainAreas()
                {
                    DomainID = i,
                    DomainName = i == 0 ? "C#" : "ASP.Net"
                };
                lst.Add(domainAreas);
            }
            return lst;
        }
    }
}
