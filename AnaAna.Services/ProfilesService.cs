using AnaAna.Data.Interfaces;
using AnaAna.Data.Models;
using AnaAna.Data.Repositories;
using AnaAna.Services.Interfaces;
using AnaAna.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnaAna.Services
{
    public class ProfilesService : IProfilesService

    {
        private readonly IRepositoryGeneric<ApplicationUser> _userRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepositoryGeneric<Poll> _pollRepo;
        private readonly IResultRepository _resultRepo;

        public ProfilesService(
            IRepositoryGeneric<ApplicationUser> repoUser,
            IHttpContextAccessor httpContextAccessor,
            IRepositoryGeneric<Poll> pollRepo,
            IResultRepository resultRepo)
        {
            _userRepo = repoUser;
            _httpContextAccessor = httpContextAccessor;
            _pollRepo = pollRepo;
            _resultRepo = resultRepo;

        }

        public async Task<RetrieveUserProfileInformationsViewModel> RetrieveUserProfileInformationAsync()
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _userRepo.GetAsync(x => x.Id == userId);
            var userPolls = await _pollRepo.GetAllAsync(x => x.CreatedBy.Id == userId);
            var userResults = await _resultRepo.GetAllAsync(x => x.User.Id == userId);

            return new RetrieveUserProfileInformationsViewModel()
            {
                CurrentUser = user,
                UserPolls = userPolls,
                UserResults = userResults
            };
        }

    }
}
