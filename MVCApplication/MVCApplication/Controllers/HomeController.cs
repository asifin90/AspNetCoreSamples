using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCApplication.Models;

namespace MVCApplication.Controllers
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
            return View();
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

        public IActionResult Test(int Id)
        {
            var i = $"Hello {Id}";
            return View();
        }

        public IActionResult Test2(string name)
        {
            var greetings = $"Hello {name}";
            return View();
        }

        public IActionResult Test3(string text)
        {
            var greetings = $"Hello {text}";
            return View();
        }

        public IActionResult Test4(string Range)
        {            
            return View();
        }
    }
}
