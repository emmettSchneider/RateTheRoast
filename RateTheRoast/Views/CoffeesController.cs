using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RateTheRoast.Data;
using RateTheRoast.Models;

namespace RateTheRoast.Views
{
    public class CoffeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoffeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Coffees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Coffee.Include(c => c.RoastIntensity).Include(c => c.Roaster);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Coffees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee
                .Include(c => c.RoastIntensity)
                .Include(c => c.Roaster)
                .FirstOrDefaultAsync(m => m.CoffeeId == id);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        // GET: Coffees/Create
        public IActionResult Create()
        {
            ViewData["RoastIntensityId"] = new SelectList(_context.RoastIntensity, "RoastIntensityId", "RoastIntensityId");
            ViewData["RoasterId"] = new SelectList(_context.Roaster, "RoasterId", "City");
            return View();
        }

        // POST: Coffees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoffeeId,RoasterId,Name,Origin,Region,Description,RoastIntensityId,ImagePath")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoastIntensityId"] = new SelectList(_context.RoastIntensity, "RoastIntensityId", "RoastIntensityId", coffee.RoastIntensityId);
            ViewData["RoasterId"] = new SelectList(_context.Roaster, "RoasterId", "City", coffee.RoasterId);
            return View(coffee);
        }

        // GET: Coffees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee.FindAsync(id);
            if (coffee == null)
            {
                return NotFound();
            }
            ViewData["RoastIntensityId"] = new SelectList(_context.RoastIntensity, "RoastIntensityId", "RoastIntensityId", coffee.RoastIntensityId);
            ViewData["RoasterId"] = new SelectList(_context.Roaster, "RoasterId", "City", coffee.RoasterId);
            return View(coffee);
        }

        // POST: Coffees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoffeeId,RoasterId,Name,Origin,Region,Description,RoastIntensityId,ImagePath")] Coffee coffee)
        {
            if (id != coffee.CoffeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeExists(coffee.CoffeeId))
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
            ViewData["RoastIntensityId"] = new SelectList(_context.RoastIntensity, "RoastIntensityId", "RoastIntensityId", coffee.RoastIntensityId);
            ViewData["RoasterId"] = new SelectList(_context.Roaster, "RoasterId", "City", coffee.RoasterId);
            return View(coffee);
        }

        // GET: Coffees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffee = await _context.Coffee
                .Include(c => c.RoastIntensity)
                .Include(c => c.Roaster)
                .FirstOrDefaultAsync(m => m.CoffeeId == id);
            if (coffee == null)
            {
                return NotFound();
            }

            return View(coffee);
        }

        // POST: Coffees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffee = await _context.Coffee.FindAsync(id);
            _context.Coffee.Remove(coffee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeeExists(int id)
        {
            return _context.Coffee.Any(e => e.CoffeeId == id);
        }
    }
}
