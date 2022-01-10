using AnaAna.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.ViewModels
{
    public class RetrieveUserProfileInformationsViewModel
    {
        public List<Poll> UserPolls { get; set; }
        public List<Result> UserResults { get; set; }
        public ApplicationUser CurrentUser { get; set; }
    }
}
