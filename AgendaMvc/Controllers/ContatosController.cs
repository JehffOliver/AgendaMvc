using Microsoft.AspNetCore.Mvc;

namespace AgendaMvc.Controllers
{
    public class ContatosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
