using AnaAna.Data.Interfaces;
using AnaAna.Data.Models;
using AnaAna.Data.Repositories;
using AnaAna.Services.Interfaces;
using AnaAna.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnaAna.Services
{
    public class ResultsService : IResultsService
    {
        private readonly IResultRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepositoryGeneric<Poll> _pollRepo;
        private readonly IRepositoryGeneric<Choice> _choiceRepo;
        private readonly IRepositoryGeneric<ApplicationUser> _userRepo;

        public ResultsService(
            IResultRepository repo,
            IHttpContextAccessor httpContextAccessor,
            IRepositoryGeneric<Poll> pollRepo,
            IRepositoryGeneric<Choice> choiceRepo,
            IRepositoryGeneric<ApplicationUser> repoUser)
        {
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            _pollRepo = pollRepo;
            _choiceRepo = choiceRepo;
            _userRepo = repoUser;
        }

        public async Task CreateResultAsync(Guid pollId, string[] choicesSelected)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var poll = await _pollRepo.GetAsync(x => x.Id == pollId);
            var user = await _userRepo.GetAsync(x => x.Id == userId);


            foreach (var choiceSelected in choicesSelected)
            {

                var choice = await _choiceRepo.GetAsync(x => x.Id == int.Parse(choiceSelected));
                var newResult = new Result()
                {
                    Choice = choice,
                    Poll = poll,
                    User = user
                };
                await _repo.AddAsync(newResult);



            }

        }

        public async Task<bool> currentUserHaveAlreadyVoted(Guid userId, Guid pollId)
        {

            var result = await _repo.GetAsync(result => result.User.Id == userId && result.Poll.Id == pollId);

            return result != null;

        }

        public async Task<ResultViewModel> getResultAndPollById(Poll poll)
        {
            int nbVoted = await getNbVotedAsync(poll.Id); 

            return new ResultViewModel()
            {
                PollId = poll.Id.ToString(),
                PollChoices = poll.Choices,
                PollDescription = poll.Description,
                PollEndedAt = poll.EndedAt,
                PollStartedAt = poll.StartedAt,
                PollTitle = poll.Title,
                NbVoted = nbVoted, 
                PollCategoryName = poll.Category.Name

            };

        }

        public async Task<ResultChartsViewModel> getResultsChartsByPollIdAsync(Poll poll)
        {


            var labels = new List<string>();
            var countChoices = new List<int>();

            foreach (Choice choice in poll.Choices)
            {
                labels.Add(choice.Label);
                var countChoice = await _repo.CountByProperty(x => x.Choice.Id == choice.Id);
                countChoices.Add(await _repo.CountByProperty(x => x.Choice.Id == choice.Id));
            }


            return new ResultChartsViewModel()
            {
                Labels = labels,
                CountChoices = countChoices,
                PollTitle = poll.Title
            };
        }

        public async Task<int> getNbVotedAsync(Guid pollId)
        {
            return await _repo.GetDistinctResults(x => x.Poll.Id == pollId);
        }

        public async Task <List<Choice>> getChoicesSelectedByPollId(Guid pollId)
        {

            var results = await _repo.GetAllAsync(x => x.Poll.Id == pollId); 
            var choices = new List<Choice>();
            foreach (Result result in results)
            {
                choices.Add(result.Choice);
            };

            return choices; 
        }

        public async Task EditResultAsync(Guid pollId, string[] choicesSelected)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var results = await _repo.GetAllAsync(x => x.Poll.Id == pollId && x.User.Id == userId);

            foreach (Result result in results)
            {
                _repo.DeleteAsync(result);
            }

            await this.CreateResultAsync(pollId, choicesSelected);

        }

    }
}
