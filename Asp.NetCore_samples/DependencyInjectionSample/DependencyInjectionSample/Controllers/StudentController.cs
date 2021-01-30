using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionSample.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepository _studentService;
        public StudentController(IStudentRepository studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View(_studentService.GetAllStudent());
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }


        [HttpPost]
        public RedirectToActionResult Create(Student stud)
        {
            _studentService.AddStudent(stud);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ViewResult Create(Student stud)
        //{
        //    _studentService.AddStudent(stud);
        //    return View();
        //}

    }
}
