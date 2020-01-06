using System;
using System.ComponentModel.DataAnnotations;

namespace MyVet.Web.Data.Entities
{
    public class History
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(100, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Remarks { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();

        [Display(Name = "Service Type")]
        public ServiceType ServiceType { get; set; }

        public Pet Pet { get; set; }
    }
}