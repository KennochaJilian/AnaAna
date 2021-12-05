using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Data.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Poll Poll { get; set; }
        [Required]
        public Choice Choice { get; set; }
        [Required]
        public IdentityUser User { get; set; }
    }
}
