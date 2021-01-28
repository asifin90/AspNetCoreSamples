using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;

namespace MVCApplication.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<Student> listStudent = new List<Student>();
            for (int i = 0; i < 3; i++)
            {
                Student objStudent = new Student();
                objStudent.Id = i;
                objStudent.FirstName = $"StudentFirstName {i}";
                objStudent.LastName = $"StudentFirstName {i}";
                objStudent.Grade = $"Grade {i}";
                objStudent.City = $"City {i}";
                listStudent.Add(objStudent);
            }
            return View(listStudent);
        }
    }
}
