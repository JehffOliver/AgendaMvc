using AgendaMvc.Data;
using AgendaMvc.Models;
using AgendaMvc.Models.ViewModels;
using AgendaMvc.Services;
using AgendaMvc.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var list = await _service.FindAllAsync();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var tiposContatos = await _contatosService.FindAllAsync();
            var viewModel = new ContatosFormViewModel { TipoContatos = tiposContatos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contatos contato)
        {
            if (!ModelState.IsValid)
            {
                var tipocontato = await _contatosService.FindAllAsync();
                var viewModel = new ContatosFormViewModel { Contato = contato, TipoContatos = tipocontato };
                return View(contato);
            }
            await _service.InsertAsync(contato);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _service.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _service.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> EditAsync(int? id)
        {
            var obj = await _service.FindByIdAsync(id.Value);

            return View(obj);
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Contatos contatos)
        {
            if (!ModelState.IsValid)
            {
                var tipocontato = await _contatosService.FindAllAsync();
                var viewModel = new ContatosFormViewModel { Contato = contatos, TipoContatos = tipocontato };
                return View(contatos);
            }
            if (id != contatos.Id)
            {
                return BadRequest();
            }
            try { 
            await _service.Update(contatos);
            return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
