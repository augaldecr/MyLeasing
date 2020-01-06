using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyVet.Web.Data.Entities
{
    public class User : IdentityUser
    {
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

        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        public string Address { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Full Name")]
        public string FullNameWithDocument => $"{FirstName} {LastName} {Document}";
    }
}
