using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.RazorEmails.Interfaces
{
    public interface IRazorViewToStringRender
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
