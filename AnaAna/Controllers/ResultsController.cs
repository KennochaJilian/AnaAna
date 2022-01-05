﻿using AnaAna.Data.Models;
using AnaAna.Services.Interfaces;
using AnaAna.Services.ViewModels;
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
    }
}
