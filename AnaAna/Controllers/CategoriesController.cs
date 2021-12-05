using AnaAna.Services.Interfaces;
using AnaAna.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnaAna.Controllers
{
    public class CategoriesController : Controller
    {
        //private readonly ICategoriesService _categoriesService;
        //public CategoriesController(ICategoriesService service)
        //{
        //    _categoriesService = service; 
        //}
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            //await _categoriesService.CreateCategoryAsync(model);

            return Redirect("index");
        }
    }
}
