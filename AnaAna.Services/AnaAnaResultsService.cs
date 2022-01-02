using AnaAna.Data.Interfaces;
using AnaAna.Data.Models;
using AnaAna.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnaAna.Services
{
    public class AnaAnaResultsService : IAnaAnaResultsService
    {
        private readonly IRepositoryGeneric<Result> _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AnaAnaResultsService(IRepositoryGeneric<Result> repo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateResultAsync(Guid pollId, int choiceId)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = new ApplicationUser { Id = userId };

            var newResult = new Result()
            {
                Choice = new Choice() { Id = choiceId },
                Poll = new Poll() { Id = pollId },
                User = user
            };

            await _repo.AddAsync(newResult);
        }

        public async Task<bool> currentUserHaveAlreadyVoted(Guid userId, Guid pollId)
        {

            var result =  await _repo.GetAsync(result => result.User.Id == userId && result.Poll.Id == pollId); 

            return result != null;

        }
    }
}
