using AnaAna.Services.ViewModels;
using System.Threading.Tasks;

namespace AnaAna.Services.Interfaces
{
    public interface IProfilesService
    {
        Task<RetrieveUserProfileInformationsViewModel> RetrieveUserProfileInformationAsync();
    }
}
