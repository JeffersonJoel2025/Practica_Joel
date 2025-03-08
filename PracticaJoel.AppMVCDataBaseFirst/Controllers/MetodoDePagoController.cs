﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaJoel.AppMVCDataBaseFirst.Models;

namespace PracticaJoel.AppMVCDataBaseFirst.Controllers
{
    public class MetodoDePagoController : Controller
    {
        private readonly CatalogosDbContext _context;

        public MetodoDePagoController(CatalogosDbContext context)
        {
            _context = context;
        }

        // GET: MetodoDePago
        public async Task<IActionResult> Index()
        {
            return View(await _context.MetodosDePagos.ToListAsync());
        }

        // GET: MetodoDePago/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodosDePago = await _context.MetodosDePagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metodosDePago == null)
            {
                return NotFound();
            }

            return View(metodosDePago);
        }

        // GET: MetodoDePago/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetodoDePago/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] MetodosDePago metodosDePago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodosDePago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metodosDePago);
        }

        // GET: MetodoDePago/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodosDePago = await _context.MetodosDePagos.FindAsync(id);
            if (metodosDePago == null)
            {
                return NotFound();
            }
            return View(metodosDePago);
        }

        // POST: MetodoDePago/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] MetodosDePago metodosDePago)
        {
            if (id != metodosDePago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodosDePago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodosDePagoExists(metodosDePago.Id))
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
            return View(metodosDePago);
        }

        // GET: MetodoDePago/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodosDePago = await _context.MetodosDePagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metodosDePago == null)
            {
                return NotFound();
            }

            return View(metodosDePago);
        }

        // POST: MetodoDePago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metodosDePago = await _context.MetodosDePagos.FindAsync(id);
            if (metodosDePago != null)
            {
                _context.MetodosDePagos.Remove(metodosDePago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodosDePagoExists(int id)
        {
            return _context.MetodosDePagos.Any(e => e.Id == id);
        }
    }
}
