using AnaAna.Services.Interfaces;
using AnaAna.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnaAna.Controllers
{
    public class PollsController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IPollsService _pollsService;
        private readonly IResultsService _resultsService;
        private readonly IEmailsService _emailsService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PollsController(
            ICategoriesService CategorieService,
            IPollsService service,
            IResultsService resultsService,
            IEmailsService emailsService,
            IHttpContextAccessor httpContextAccessor)
        {
            _categoriesService = CategorieService;
            _pollsService = service;
            _resultsService = resultsService;
            _emailsService = emailsService;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<IActionResult> Index([FromQuery(Name = "category")] string queryCategoryName, string categoryName, int page = 1)
        {
            if(categoryName == null)
            {
                categoryName = queryCategoryName; 
            }
            var data = await _pollsService.GetAllAsync(categoryName);
            data.CurrentPage = page;
            data.PollsPerPage = 5; 
            ViewData["categorySelected"] = categoryName; 
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
           
            var choices = Request.Form["Choices"].ToString().Split(',').ToList();


            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var newPoll = await _pollsService.CreatePollAsync(model, choices);
            _emailsService.PrepareAndSendCreatingPollEmailAsync(newPoll);

            return Redirect($"Retrieve/{newPoll.Id}?create=true");
        }

        [HttpGet]
        public async Task<IActionResult> Retrieve(string id, [FromQuery(Name = "create")] string afterCreate )
        {
            var data = await _pollsService.GetOneByIdAsync(Guid.Parse(id));
            ViewData["fromCreate"] = null;

            if (data.UserAlreadyVoted)
            {
                ViewData["mode"] = "EditResult";
            }
            else
            {
                ViewData["mode"] = "CreateResult";
            }
            if(afterCreate != null)
            {
                ViewData["fromCreate"] = "ok";
            }

            return View(data);

        }



        [HttpGet]
        public async Task<IActionResult> Desactivate([FromQuery(Name = "pollId")] string pollId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentPoll = await _pollsService.GetOneByIdAsyncNoVM(Guid.Parse(pollId)); 

            if(Guid.Parse(userId) != currentPoll.CreatedBy.Id )
            {
                return Unauthorized();
            }

            await _pollsService.Update<bool>(Guid.Parse(pollId), "IsDisabled", true);
            await _pollsService.Update<DateTime>(Guid.Parse(pollId), "EndedAt", DateTime.Now);
            return Ok();

        }
    }
}
