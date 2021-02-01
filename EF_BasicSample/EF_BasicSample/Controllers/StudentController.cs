using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_BasicSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_BasicSample.Controllers
{
    public class StudentController : Controller
    {
        SQLDbContext context;
        public StudentController(SQLDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View(context.Students.ToList());
        }
    }
}
