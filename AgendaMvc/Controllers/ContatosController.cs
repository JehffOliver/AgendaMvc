using AgendaMvc.Data;
using AgendaMvc.Models;
using AgendaMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMvc.Controllers
{
    public class ContatosController : Controller
    {
        private readonly ContactService _service;

        public ContatosController(ContactService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var list = _service.FindAll();

            return View(list);
        }
    }
}
