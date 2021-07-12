using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelFileRead.Models
{
    public class StaffInfoViewModel
    {
        public string StaffId { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Email { get; set;}
        public List<StaffInfoViewModel> StaffList { get; set;}
        public StaffInfoViewModel()
        {
            StaffList = new List<StaffInfoViewModel>();
        }
    }
}
