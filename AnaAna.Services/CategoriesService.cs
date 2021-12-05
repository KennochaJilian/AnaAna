using AnaAna.Data;
using AnaAna.Data.Interfaces;
using AnaAna.Data.Models;
using AnaAna.Data.Repositories;
using AnaAna.Services.Interfaces;
using AnaAna.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services
{
    public class CategoriesService:ICategoriesService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRepositoryGeneric<Category> _repo;

        public CategoriesService(ApplicationDbContext dbContext,IRepositoryGeneric<Category> repo)
        {   
            _dbContext = dbContext;
            _repo = repo;
        }

        public async Task CreateCategoryAsync(AddCategoryViewModel category)
        {
            var NewCategory = new Category(); 
            NewCategory.Name = category.Name;
            await _repo.AddAsync(NewCategory); 

        }

        public Task<List<CategoriesIndexViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
