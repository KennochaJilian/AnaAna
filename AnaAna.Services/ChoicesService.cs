using AnaAna.Data.Interfaces;
using AnaAna.Data.Models;
using AnaAna.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services
{
    public class ChoicesService : IChoicesService
    {
        private readonly IRepositoryGeneric<Choice> _repo;

        public ChoicesService(IRepositoryGeneric<Choice> repo)
        {
            
            _repo = repo;

        }
        public async Task CreateChoicesAsync(Poll poll, string choice)
        {

            var newChoice = new Choice()
            {
                Poll = poll,
                Label = choice

            };
            await _repo.AddAsync(newChoice);
        }
    }
}
