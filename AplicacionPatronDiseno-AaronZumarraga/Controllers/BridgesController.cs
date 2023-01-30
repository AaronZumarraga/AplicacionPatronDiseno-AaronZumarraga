using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicacionPatronDiseno_AaronZumarraga.Data;
using AplicacionPatronDiseno_AaronZumarraga.Models;

namespace AplicacionPatronDiseno_AaronZumarraga.Controllers
{
    public class BridgesController : Controller
    {
        private readonly AplicacionPatronDiseno_AaronZumarragaContext _context;

        public BridgesController(AplicacionPatronDiseno_AaronZumarragaContext context)
        {
            _context = context;
        }

        // GET: Bridges
        public async Task<IActionResult> Index()
        {
              return View(await _context.Bridge.ToListAsync());
        }

        // GET: Bridges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bridge == null)
            {
                return NotFound();
            }

            var bridge = await _context.Bridge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bridge == null)
            {
                return NotFound();
            }

            return View(bridge);
        }

        // GET: Bridges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bridges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Apellido,Edad")] Bridge bridge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bridge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bridge);
        }

        // GET: Bridges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bridge == null)
            {
                return NotFound();
            }

            var bridge = await _context.Bridge.FindAsync(id);
            if (bridge == null)
            {
                return NotFound();
            }
            return View(bridge);
        }

        // POST: Bridges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Apellido,Edad")] Bridge bridge)
        {
            if (id != bridge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bridge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BridgeExists(bridge.Id))
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
            return View(bridge);
        }

        // GET: Bridges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bridge == null)
            {
                return NotFound();
            }

            var bridge = await _context.Bridge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bridge == null)
            {
                return NotFound();
            }

            return View(bridge);
        }

        // POST: Bridges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bridge == null)
            {
                return Problem("Entity set 'AplicacionPatronDiseno_AaronZumarragaContext.Bridge'  is null.");
            }
            var bridge = await _context.Bridge.FindAsync(id);
            if (bridge != null)
            {
                _context.Bridge.Remove(bridge);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BridgeExists(int id)
        {
          return _context.Bridge.Any(e => e.Id == id);
        }
    }
}
