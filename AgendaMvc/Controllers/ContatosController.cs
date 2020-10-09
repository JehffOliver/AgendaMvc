﻿using AgendaMvc.Data;
using AgendaMvc.Models;
using AgendaMvc.Models.ViewModels;
using AgendaMvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

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

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _service.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _service.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
