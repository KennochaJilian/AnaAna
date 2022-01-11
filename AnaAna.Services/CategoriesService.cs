using AnaAna.Data;
using AnaAna.Data.Interfaces;
using AnaAna.Data.Models;
using AnaAna.Data.Repositories;
using AnaAna.Services.Interfaces;
using AnaAna.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public async Task<List<Category>> GetAllNoVMAsync()
        {
            var categories = await _repo.GetAllAsync();


            //var enumerable = categories.Select(category => new CategoriesIndexViewModel()
            //{
            //    Name = category.Name,
            //    Id = category.Id

            //});

            return categories;
        }

        public async Task<Category> GetOneByIdNoVMAsync(int id)
        {
            PropertyInfo idProperty = typeof(Category).GetProperty("Id");
            var category = await _repo.GetAsync(x => x.Id == id);

            return category; 
        }
    }
}
