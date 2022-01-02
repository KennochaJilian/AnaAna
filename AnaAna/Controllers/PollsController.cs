using AnaAna.Services.Interfaces;
using AnaAna.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnaAna.Controllers
{
    public class PollsController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IPollsService _pollsService;
        private readonly IAnaAnaResultsService _resultsService;
        public PollsController(ICategoriesService CategorieService, IPollsService service, IAnaAnaResultsService resultsService)
        {
            _categoriesService = CategorieService;
            _pollsService = service;
            _resultsService = resultsService; 

        }
        public async Task<IActionResult> Index([FromQuery(Name = "category")] string categoryName)
        {
            var data = await _pollsService.GetAllAsync();

            return View(data);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var vm = new AddPollViewModel(); 
            var categories = await _categoriesService.GetAllNoVMAsync();
            vm.Categories = categories; 

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPollViewModel model)
        {
            var selectedId = Request.Form["Tags"];
            var choices = Request.Form["Choices"].ToString().Split(',').ToList();
             

            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            await _pollsService.CreatePollAsync(model, int.Parse(selectedId), choices); 

            return Redirect("index");
        }

        [HttpGet]
        public async Task<IActionResult> Retrieve(string id)
        {
            var data = await _pollsService.GetOneByIdAsync(Guid.Parse(id));
            return View(data); 

        }

        [HttpPost]
        public async Task<IActionResult> CreateResult(IFormCollection collection)
        {
            
            await _resultsService.CreateResultAsync(Guid.Parse(collection["pollId"]), int.Parse(collection["choicesSelected"])); 
            return Redirect("index");

        }
    }
}
