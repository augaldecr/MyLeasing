using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Models
{
    public class AddUserViewModel : EditUserViewModel
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(30, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(20, MinimumLength =6, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Password Confirm")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
