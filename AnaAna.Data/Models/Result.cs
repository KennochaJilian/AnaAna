using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Data.Models
{
    public class Result: IIncludeObject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Poll Poll { get; set; }
        [Required]
        public Choice Choice { get; set; }
        [Required]
        public ApplicationUser User { get; set; }

        public List<string> IncludesNeeded()
        {
            return new List<string>() { "Choice", "Poll"}; 
        }
    }
}
