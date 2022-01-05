using AnaAna.Data.Models;
using AnaAna.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.Interfaces
{
    public interface IResultsService
    {
        Task CreateResultAsync(Guid pollId, string[] collection);
        Task<bool> currentUserHaveAlreadyVoted(Guid userId, Guid pollId);
        Task<ResultChartsViewModel> getResultsChartsByPollIdAsync(Poll poll);
        Task<ResultViewModel> getResultAndPollById(Poll Poll);
        Task<int> getNbVotedAsync(Guid pollId);
        Task<List<Choice>> getChoicesSelectedByPollId(Guid pollId);
        Task EditResultAsync(Guid pollId, string[] choicesSelected);

    }
}
