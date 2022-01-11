using AnaAna.Data.Models;
using AnaAna.Services.Interfaces;
using AnaAna.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AnaAna.Controllers
{
    public class ResultsController : Controller
    {
        private readonly IResultsService _service; 
        private readonly IPollsService _pollsService;
        public ResultsController(IResultsService service, IPollsService pollsService)
        {
            _service = service;
            _pollsService = pollsService;

        }
        public async Task<IActionResult> Index([FromQuery(Name = "pollId")] string pollId)
        {
            var poll = await _pollsService.GetOneByIdAsyncNoVM(Guid.Parse(pollId));
            var data = await _service.getResultAndPollById(poll); 
            return View(data);
        }
        public async Task<IActionResult> Charts([FromQuery(Name = "pollId")] string pollId)
        {
            var currentPoll = await _pollsService.GetOneByIdAsyncNoVM(Guid.Parse(pollId)); 
            var charts = _service.getResultsChartsByPollIdAsync(currentPoll); 
            return Ok(charts.Result); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateResult(IFormCollection collection)
        {



            await _service.CreateResultAsync(Guid.Parse(collection["pollId"]), collection["choicesSelected"]);


            return Redirect($"~/Results/index?pollId={collection["pollId"]}");

        }

        [HttpPost]
        public async Task<IActionResult> EditResult(IFormCollection collection)
        {

            await _service.EditResultAsync(Guid.Parse(collection["pollId"]), collection["choicesSelected"]);

            return Redirect($"~/Results/index?pollId={collection["pollId"]}");

        }
    }
}
