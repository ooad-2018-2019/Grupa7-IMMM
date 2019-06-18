﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CalTrek.Models;
using CalTrekApp.Models;

namespace CalTrek.Controllers
{
    public class KlijentController : Controller
    {
        private readonly CalTrekContext _context;

        public KlijentController(CalTrekContext context)
        {
            _context = context;
        }

        // GET: Klijent
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klijent.ToListAsync());
        }

        // GET: Klijent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _context.Klijent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klijent == null)
            {
                return NotFound();
            }

            return View(klijent);
        }

        // GET: Klijent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klijent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Ime,Prezime,DatumRodjenja,Spol,Grad,Drzava")] Klijent klijent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klijent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klijent);
        }

        // GET: Klijent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _context.Klijent.FindAsync(id);
            if (klijent == null)
            {
                return NotFound();
            }
            return View(klijent);
        }

        // POST: Klijent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Username,Ime,Prezime,DatumRodjenja,Spol,Grad,Drzava")] Klijent klijent)
        {
            if (id != klijent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klijent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlijentExists(klijent.Id))
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
            return View(klijent);
        }

        // GET: Klijent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klijent = await _context.Klijent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klijent == null)
            {
                return NotFound();
            }

            return View(klijent);
        }

        // POST: Klijent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klijent = await _context.Klijent.FindAsync(id);
            _context.Klijent.Remove(klijent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlijentExists(int id)
        {
            return _context.Klijent.Any(e => e.Id == id);
        }
    }
}
