using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVet.Web.Data.Entities
{
    public class ServiceType
    {
        public int Id { get; set; }

        [Display(Name = "Service Type")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        public string Name { get; set; }

        public ICollection<History> Histories { get; set; }
    }
}
