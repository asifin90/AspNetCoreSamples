using System;
using Microsoft.AspNetCore.Mvc;
using ExcelFileRead.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
//using OfficeOpenXml;
using System.Linq;

namespace ExcelFileRead.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult File()
        {
            FileUploadViewModel model = new FileUploadViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult File(FileUploadViewModel model)
        {
            string rootFolder = _hostingEnvironment.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + model.XlsFile.FileName;
            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

            return View();            
        }

    }
}
