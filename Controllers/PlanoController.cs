﻿using System;
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
    public class PlanoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plano
        public async Task<IActionResult> Index()
        {
              return _context.Plano != null ? 
                          View(await _context.Plano.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Plano'  is null.");
        }

        // GET: Plano/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plano == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano
                .FirstOrDefaultAsync(m => m.PlanoId == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // GET: Plano/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plano/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanoId,Nome,DiasPorSemana")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plano);
        }

        // GET: Plano/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plano == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano.FindAsync(id);
            if (plano == null)
            {
                return NotFound();
            }
            return View(plano);
        }

        // POST: Plano/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanoId,Nome,DiasPorSemana")] Plano plano)
        {
            if (id != plano.PlanoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoExists(plano.PlanoId))
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
            return View(plano);
        }

        // GET: Plano/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plano == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano
                .FirstOrDefaultAsync(m => m.PlanoId == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // POST: Plano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plano == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Plano'  is null.");
            }
            var plano = await _context.Plano.FindAsync(id);
            if (plano != null)
            {
                _context.Plano.Remove(plano);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoExists(int id)
        {
          return (_context.Plano?.Any(e => e.PlanoId == id)).GetValueOrDefault();
        }
    }
}
