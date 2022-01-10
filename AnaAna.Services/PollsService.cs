using AnaAna.Data;
using AnaAna.Data.Interfaces;
using AnaAna.Data.Models;
using AnaAna.Services.Interfaces;
using AnaAna.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnaAna.Services
{
    public class PollsService : IPollsService
    {

        private readonly IRepositoryGeneric<Poll> _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IChoicesService _choicesService;
        private readonly IResultsService _anaAnaResultsService;
        private readonly IRepositoryGeneric<ApplicationUser> _userRepo;
        private readonly IRepositoryGeneric<Category> _categoryRepo;

        public PollsService(
            IHttpContextAccessor httpContextAccessor,
            IRepositoryGeneric<Poll> repo,
            IChoicesService choicesService,
            IResultsService resultsService,
            IRepositoryGeneric<ApplicationUser> repoUser,
            IRepositoryGeneric<Category> categoriesRepo

            )
        {
            _httpContextAccessor = httpContextAccessor;
            _repo = repo;
            _choicesService = choicesService;
            _anaAnaResultsService = resultsService;
            _userRepo = repoUser; 
            _categoryRepo = categoriesRepo;
                


        }
        public async Task<Poll> CreatePollAsync(AddPollViewModel Poll, List<string> choices)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = await _userRepo.GetAsync(x => x.Id == userId);

            var category = new Category { Id = Poll.CategoryId};

            var newPoll = new Poll()
            {
                Category = category,
                Title = Poll.Title,
                StartedAt = DateTime.Now,
                EndedAt = Poll.EndedAt,
                Description = Poll.Description,
                IsDisabled = false,
                IsPrivate = Poll.IsPrivate,
                HasMultipleChoice = Poll.HasMultipleChoice,
                CreatedBy = user
            };

            await _repo.AddAsync(newPoll);

            foreach (string choice in choices)
            {
                await _choicesService.CreateChoicesAsync(newPoll, choice);
            }
            return newPoll; 
        }

        public async Task<PollsIndexViewModel> GetAllAsync(string categoryName = null)
        {
            Expression<Func<Poll, bool>> predicate = x => !x.IsPrivate; 
            if(categoryName != null)
            {
                predicate = x => !x.IsPrivate && x.Category.Name == categoryName;
            }
            var polls = await _repo.GetAllAsync(predicate);
            var categories = await _categoryRepo.GetAllAsync();




            return new PollsIndexViewModel
            {
                Categories = categories,
                Polls = polls
            }; 

        }

        public async Task<RetrievePollViewModel> GetOneByIdAsync(Guid id)
        {
            PropertyInfo idProperty = typeof(Poll).GetProperty("Id");
            var poll = await _repo.GetAsync(x => x.Id == id);

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


            var nbVoted = await _anaAnaResultsService.getNbVotedAsync(poll.Id);


            bool userAlreadyVoted = false;
            bool userIsCreator = false;
            List<Choice> choicesSelected = null; 

            if (userId != null)
            {

                userAlreadyVoted = await _anaAnaResultsService.currentUserHaveAlreadyVoted(Guid.Parse(userId), poll.Id);

                if (Guid.Parse(userId) == poll.CreatedBy.Id)
                {
                    userIsCreator = true;
                }

                if (userAlreadyVoted)
                {
                    choicesSelected = await _anaAnaResultsService.getChoicesSelectedByPollId(poll.Id);
                }
            }




            return new RetrievePollViewModel()
            {
                Title = poll.Title,
                Description = poll.Description,
                StartedAd = poll.StartedAt,
                EndedAt = poll.EndedAt,
                HasMultipleChoice = poll.HasMultipleChoice,
                Category = poll.Category,
                Choices = poll.Choices,
                Id = poll.Id,
                UserAlreadyVoted = userAlreadyVoted,
                userIsCreator = userIsCreator,
                IsDisabled = poll.IsDisabled,
                nbVoted = nbVoted, 
                ChoicesSelected = choicesSelected,

            };

        }
        public async Task<Poll> GetOneByIdAsyncNoVM(Guid Id)
        {
            PropertyInfo idProperty = typeof(Poll).GetProperty("Id");
            var poll = await _repo.GetAsync(x => x.Id == Id);
            return poll;
        }

        public async Task<Poll> Update<T>(Guid Id, string property, T changes) where T : struct
        {
            
            var poll = await _repo.GetAsync(x => x.Id == Id);
            poll.GetType().GetProperty(property).SetValue(poll,changes);
            await _repo.UpdateAsync(poll);

            return poll; 
        }


    }
}
