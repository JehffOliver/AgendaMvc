using AgendaMvc.Data;
using AgendaMvc.Models;
using AgendaMvc.Models.ViewModels;
using AgendaMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMvc.Controllers
{
    public class ContatosController : Controller
    {
        private readonly ContactService _service;
        private readonly TipoContatosService _contatosService;

        public ContatosController(ContactService service, TipoContatosService contatoService)
        {
            _service = service;
            _contatosService = contatoService;
        }

        public IActionResult Index()
        {
            var list = _service.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var tiposContatos = _contatosService.FindAll();
            var viewModel = new ContatosFormViewModel { TipoContatos = tiposContatos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contatos contato)
        {
            _service.Insert(contato);
            return RedirectToAction(nameof(Index));
        }
    }
}
