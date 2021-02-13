using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApplication.Models
{
    public class UserModel
    {

        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsDealer { get; set; }
        public bool IsAppUser { get; set; }

    }
}
