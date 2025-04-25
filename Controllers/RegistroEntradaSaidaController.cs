using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoMensalidade2.Data;
using GerenciamentoMensalidade2.Models;

namespace GerenciamentoMensalidade2.Controllers
{
    public class RegistroEntradaSaidaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroEntradaSaidaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroEntradaSaida
        public async Task<IActionResult> Index()
        {
              return _context.RegistroEntradaSaida != null ? 
                          View(await _context.RegistroEntradaSaida.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RegistroEntradaSaida'  is null.");
        }

        // GET: RegistroEntradaSaida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RegistroEntradaSaida == null)
            {
                return NotFound();
            }

            var registroEntradaSaida = await _context.RegistroEntradaSaida
                .FirstOrDefaultAsync(m => m.RegistroEntradaSaidaId == id);
            if (registroEntradaSaida == null)
            {
                return NotFound();
            }

            return View(registroEntradaSaida);
        }

        // GET: RegistroEntradaSaida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistroEntradaSaida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistroEntradaSaidaId,Entrada,Saida")] RegistroEntradaSaida registroEntradaSaida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroEntradaSaida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroEntradaSaida);
        }

        // GET: RegistroEntradaSaida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RegistroEntradaSaida == null)
            {
                return NotFound();
            }

            var registroEntradaSaida = await _context.RegistroEntradaSaida.FindAsync(id);
            if (registroEntradaSaida == null)
            {
                return NotFound();
            }
            return View(registroEntradaSaida);
        }

        // POST: RegistroEntradaSaida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistroEntradaSaidaId,Entrada,Saida")] RegistroEntradaSaida registroEntradaSaida)
        {
            if (id != registroEntradaSaida.RegistroEntradaSaidaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroEntradaSaida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroEntradaSaidaExists(registroEntradaSaida.RegistroEntradaSaidaId))
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
            return View(registroEntradaSaida);
        }

        // GET: RegistroEntradaSaida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RegistroEntradaSaida == null)
            {
                return NotFound();
            }

            var registroEntradaSaida = await _context.RegistroEntradaSaida
                .FirstOrDefaultAsync(m => m.RegistroEntradaSaidaId == id);
            if (registroEntradaSaida == null)
            {
                return NotFound();
            }

            return View(registroEntradaSaida);
        }

        // POST: RegistroEntradaSaida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RegistroEntradaSaida == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RegistroEntradaSaida'  is null.");
            }
            var registroEntradaSaida = await _context.RegistroEntradaSaida.FindAsync(id);
            if (registroEntradaSaida != null)
            {
                _context.RegistroEntradaSaida.Remove(registroEntradaSaida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroEntradaSaidaExists(int id)
        {
          return (_context.RegistroEntradaSaida?.Any(e => e.RegistroEntradaSaidaId == id)).GetValueOrDefault();
        }
    }
}
