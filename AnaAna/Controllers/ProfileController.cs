using AnaAna.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnaAna.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfilesService _service; 
        public ProfileController(IProfilesService service)
        {
          _service = service;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var data = await _service.RetrieveUserProfileInformationAsync(); 

            return View(data);
        }
    }
}
