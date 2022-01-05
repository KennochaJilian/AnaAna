using AnaAna.Data.Models;
using AnaAna.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.Interfaces
{
    public interface IPollsService
    {
        Task<Poll> CreatePollAsync(AddPollViewModel Poll, int IdCategory, List<string> choices);
        Task<List<PollsIndexViewModel>> GetAllAsync();

        Task <RetrievePollViewModel> GetOneByIdAsync(Guid id);
        Task<Poll> GetOneByIdAsyncNoVM(Guid id);
        Task<Poll> Update<T>(Guid Id, string property, T changes) where T: struct; 

    }
}
