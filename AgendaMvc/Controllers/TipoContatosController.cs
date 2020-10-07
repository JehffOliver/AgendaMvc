using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaMvc.Data;
using AgendaMvc.Models;

namespace AgendaMvc.Controllers
{
    public class TipoContatosController : Controller
    {
        private readonly AgendaMvcContext _context;

        public TipoContatosController(AgendaMvcContext context)
        {
            _context = context;
        }

        // GET: TipoContatos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoContato.ToListAsync());
        }

        // GET: TipoContatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContato = await _context.TipoContato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoContato == null)
            {
                return NotFound();
            }

            return View(tipoContato);
        }

        // GET: TipoContatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoContatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TipoContato tipoContato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoContato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoContato);
        }

        // GET: TipoContatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContato = await _context.TipoContato.FindAsync(id);
            if (tipoContato == null)
            {
                return NotFound();
            }
            return View(tipoContato);
        }

        // POST: TipoContatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TipoContato tipoContato)
        {
            if (id != tipoContato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoContato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoContatoExists(tipoContato.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoContato);
        }

        // GET: TipoContatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContato = await _context.TipoContato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoContato == null)
            {
                return NotFound();
            }

            return View(tipoContato);
        }

        // POST: TipoContatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoContato = await _context.TipoContato.FindAsync(id);
            _context.TipoContato.Remove(tipoContato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoContatoExists(int id)
        {
            return _context.TipoContato.Any(e => e.Id == id);
        }
    }
}
