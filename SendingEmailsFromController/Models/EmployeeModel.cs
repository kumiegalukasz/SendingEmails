using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SendingEmailsFromController.Models
{
    public class EmployeeModel
    {
        [DataType(DataType.EmailAddress), Display(Name = "Do")]
        [Required(ErrorMessage ="Proszę podać adres e-mail")]
        public string ToEmail { get; set; }
        [Display(Name = "Temat")]
        public string EmailSubject { get; set; }
        [Display(Name = "Treść")]
        [DataType(DataType.MultilineText)]
        public string EMailBody { get; set; }
       
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Kopia")]
        public string EmailCC { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Proszę podać login")]
        public string Email { get; set; }

        [DataType(DataType.Password), Display(Name = "Haslo")]
        [Required (ErrorMessage ="Proszę podać hasło")]
        public string Password { get; set; }
    }
}