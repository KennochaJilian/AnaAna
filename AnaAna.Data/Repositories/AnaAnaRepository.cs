using AnaAna.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Data.Repositories
{
    public class AnaAnaRepository<T> : RepositoryGeneric<T> where T : class, IIncludeObject, new()
    {
        public AnaAnaRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
