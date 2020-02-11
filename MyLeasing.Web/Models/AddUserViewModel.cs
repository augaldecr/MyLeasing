using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Models
{
    public class AddUserViewModel
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(30, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(30, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        public string Document { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        [Display(Name = "Last Name")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        public string Address { get; set; }

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
