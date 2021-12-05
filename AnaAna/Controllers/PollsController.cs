using Microsoft.AspNetCore.Mvc;

namespace AnaAna.Controllers
{
    public class PollsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
