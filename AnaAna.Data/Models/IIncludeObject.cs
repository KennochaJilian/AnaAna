using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Data.Models
{
    public interface IIncludeObject
    {
        List<string> IncludesNeeded();
    }
}
