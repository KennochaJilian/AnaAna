using AnaAna.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.ViewModels
{
    public class AddPollViewModel
    {
        [Required(ErrorMessage = "Le titre doit être renseigné")]
        [Display(Name = "Nom du sondage")]
        public string Title { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd / MM / yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de fin")]
        public DateTime EndedAt { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Sondage privé")]
        public bool IsPrivate { get; set; }
        [Display(Name = "Choix multiple")]
        public bool HasMultipleChoice { get; set; }
        
        [Display(Name = "Categorie du sondage")]
        public List<Category> Categories{ get; set;}
        public int CategoryId { get; set; }

    }
}
