using AnaAna.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.ViewModels
{
    public class PollsIndexViewModel
    {
        public List<Poll> Polls { get; set; }
        public List<Category> Categories { get; set; }
        public int PollsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount()
    {
        return Convert.ToInt32(Math.Ceiling(Polls.Count() / (double)PollsPerPage));
    }
    public IEnumerable<Poll> PaginatedBlogs()
    {
        int start = (CurrentPage - 1) * PollsPerPage;
        return Polls.OrderByDescending(x => x.StartedAt).Skip(start).Take(PollsPerPage);
    }
    }


}
