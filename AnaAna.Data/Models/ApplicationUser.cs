using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>, IIncludeObject
    {

        [PersonalData]
        public string name { get; set; }

        public List<string> IncludesNeeded()
        {
            return new List<string>();
        }
    }
}
