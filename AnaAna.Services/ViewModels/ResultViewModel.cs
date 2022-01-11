using AnaAna.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.ViewModels
{
    public class ResultViewModel
    {
        public string PollId { get; set; }
        public string PollTitle { get; set; }
        public List<Choice> PollChoices { get; set; }
        public DateTime PollStartedAt { get; set; }
        public DateTime PollEndedAt { get; set; }
        public string PollDescription { get; set; }
        public int NbVoted { get; set; }
        public string PollCategoryName { get; set; }
        public bool PollIsDisabled { get; set; }


    }
}
