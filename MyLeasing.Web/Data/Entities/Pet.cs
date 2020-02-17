using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVet.Web.Data.Entities
{
    public class Pet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters.")]
        public string Race { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Born { get; set; }

        public string Remarks { get; set; }

        //public ICollection<History> Histories { get; set; }

        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
            : $"https://myvetalonso.azurewebsites.net/{ImageUrl.Substring(1)}";

        [Display(Name = "Born")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime BornLocal => Born.ToLocalTime();

        [Display(Name ="Pet Type")]
        public PetType PetType { get; set; }

        public Owner Owner { get; set; }

        public ICollection<History> Histories { get; set; }

        public ICollection<Agenda> Agendas { get; set; }
    }
}