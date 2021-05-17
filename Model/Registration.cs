using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivyaAirlineData.Model
{
    public class Registration
    {
        
        public string Username {get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        [NotMapped]
        [CompareAttribute("Password",ErrorMessage ="Password Do not match")]
        public string ConfirmPassword { get; set; }


    }
}
