using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.ViewModels
{
    public class ResultChartsViewModel
    {
        public List<string> Labels { get; set; }
        public List<int> CountChoices { get; set; }
        public string PollTitle { get; set; }
    }
}
