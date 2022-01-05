using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Data.Models
{
    public class Choice : IIncludeObject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Label { get; set; }
        [Required]
        public Poll Poll { get; set; }

        public List<string> IncludesNeeded()
        {
            return new List<string>();
        }
    }
}
