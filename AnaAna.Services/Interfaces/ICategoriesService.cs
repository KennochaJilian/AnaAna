using AnaAna.Data.Models;
using AnaAna.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<Category>> GetAllNoVMAsync(); 

        Task <Category> GetOneByIdNoVMAsync(int id);

    }
}
