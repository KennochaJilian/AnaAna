using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AnaAna.Data.Models
{
    public class Poll : IIncludeObject
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartedAt { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndedAt { get; set; }
        [Required]
        public bool IsDisabled { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsPrivate { get; set; }
        [Required]
        public ApplicationUser CreatedBy { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public bool HasMultipleChoice { get; set; }

        public List<Choice> Choices { get; set; }   

        public List<string> IncludesNeeded()
        {
            return new List<string>() {"Category", "Choices", "CreatedBy"};
        }
    }
}
