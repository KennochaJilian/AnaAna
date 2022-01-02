﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Data.Models
{
    public class Category :IIncludeObject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public List<string> IncludesNeeded()
        {
            return new List<string>(); 
        }
    }
}
