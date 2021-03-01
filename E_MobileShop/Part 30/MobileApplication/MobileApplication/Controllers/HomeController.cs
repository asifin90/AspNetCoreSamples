using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileApplication.Models;

namespace MobileApplication.Controllers
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

        
        public IActionResult HttpErrors()
        {
            int errCode = HttpContext.Response.StatusCode;
            if (errCode == 404) 
            {
                ViewBag.ErrorCode = "404";
            }
            if (errCode == 500)
            {
                ViewBag.ErrorCode = "500";
            }
            return View();
        }

        // If there is 404 status code, the route path will become Error/404
        [Route("Error/{statusCode}")]
        public IActionResult HttpErrors(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorCode = "Sorry, requested resource not found";
                    break;
            }

            return View();
        }

    }
}
