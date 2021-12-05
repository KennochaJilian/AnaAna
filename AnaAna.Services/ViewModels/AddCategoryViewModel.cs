using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required(ErrorMessage = "Le nom de la catégorie est obligatoire")]
        [Display(Name = "Titre de la catégorie")]
        [StringLength(100, ErrorMessage = "Taille invalide, 100 caractères maximum")]
        public string Name { get; set; }
    }
}
