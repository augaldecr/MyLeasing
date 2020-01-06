using System;
using System.ComponentModel.DataAnnotations;

namespace MyVet.Web.Data.Entities
{
    public class Agenda
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        //public Owner Owner { get; set; }

        //public Pet Pet { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "Is Avaible?")]
        public bool IsAvaible { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateLocal => Date.ToLocalTime();

        public Owner Owner { get; set; }

        public Pet Pet { get; set; }
    }
}
