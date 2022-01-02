using AnaAna.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.Interfaces
{
    public interface IChoicesService
    {
        Task CreateChoicesAsync(Poll poll, string choice);
    }
}
