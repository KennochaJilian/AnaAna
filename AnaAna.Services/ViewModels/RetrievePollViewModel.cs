using AnaAna.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.ViewModels
{
    public class RetrievePollViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        
        public DateTime EndedAt { get; set; }

        public DateTime StartedAd { get; set; }

        public string Description { get; set; }
        public bool HasMultipleChoice { get; set; }

        public bool UserAlreadyVoted { get; set; }

        public bool userIsCreator { get; set; }

        public bool IsDisabled { get; set; }

        public Category Category { get; set; }

        public List<Choice> Choices { get; set; }
        public int nbVoted { get; set; }

        public List<Choice> ChoicesSelected { get; set; }
    }
}
