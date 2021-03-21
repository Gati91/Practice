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
            x.DomainAreas = selectListItems();
            
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

        public Dictionary<int, string> GenerateDomainAreas()
        {
            var lst = new Dictionary<int, string>();
            lst.Add(1, "C#");
            lst.Add(2, "F#");
            return lst;
        }

        public List<SelectListItem> selectListItems()
        {
            var x = new List<SelectListItem>();
            foreach (var item in GenerateDomainAreas())
            {
                x.Add(new SelectListItem
                {
                    Text = item.Value,
                    Value = item.Key.ToString()
                });
            }
            return x;
        }
    }
}
