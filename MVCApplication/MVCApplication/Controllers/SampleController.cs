using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCApplication.Controllers
{
    public class SampleController : Controller
    {
        public string Index(int Id)
        {
            return Id.ToString();
        }
    }
}
