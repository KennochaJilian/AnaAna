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
        private readonly IAnaAnaResultsService _anaAnaResultsService;


        public PollsService(
            IHttpContextAccessor httpContextAccessor, 
            IRepositoryGeneric<Poll> repo, 
            IChoicesService choicesService, 
            IAnaAnaResultsService resultsService)
        {
            _httpContextAccessor = httpContextAccessor;
            _repo = repo;
            _choicesService = choicesService; 
            _anaAnaResultsService = resultsService;


        }
        public async Task CreatePollAsync(AddPollViewModel Poll, int IdCategory, List<string> choices)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = new ApplicationUser { Id = userId };

            var category = new Category { Id = IdCategory };

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
        }

        public async Task<List<PollsIndexViewModel>> GetAllAsync()
        {
            var polls = await _repo.GetAllAsync();


            var enumerable = polls.Select(poll => new PollsIndexViewModel()
            {
                Description = poll.Description,
                Title = poll.Title,
                Id = poll.Id,


            }); 
            

            return enumerable.ToList();
        }

        public async Task<RetrievePollViewModel> GetOneByIdAsync(Guid id)
        {
            PropertyInfo idProperty = typeof(Poll).GetProperty("Id");
            var poll = await _repo.GetAsync(x => x.Id == id);

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); 


            bool userAlreadyVoted = false; 

            if(userId != null)
            {
                
                userAlreadyVoted = await _anaAnaResultsService.currentUserHaveAlreadyVoted(Guid.Parse(userId), poll.Id);
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
                UserAlreadyVoted = userAlreadyVoted
            };
            
        }
    }
}
