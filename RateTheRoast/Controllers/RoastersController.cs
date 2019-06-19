using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RateTheRoast.Data;
using RateTheRoast.Models;
using RateTheRoast.Models.ViewModels;

namespace RateTheRoast.Controllers
{
    public class RoastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Roasters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Roaster.Include(r => r.State).Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> State(string id)
        {
            var roasters = _context.Roaster
                .Include(r => r.State)
                .Include(r => r.User)
                .Where(r => r.StateAbbrev == id);
            if (roasters == null)
            {
                return NotFound();
            }
            return View(await roasters.ToListAsync());
        }

        // GET: Roasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roaster = await _context.Roaster
                .Include(r => r.State)
                .Include(r => r.Coffees).ThenInclude(c => c.RoastIntensity)
                .FirstOrDefaultAsync(m => m.RoasterId == id);


            if (roaster == null)
            {
                return NotFound();
            }

            return View(roaster);
        }

        // GET: Roasters/Create
        public IActionResult Create()
        {
            ViewData["StateAbbrev"] = new SelectList(_context.State, "StateAbbrev", "StateAbbrev");
            return View();
        }

        // POST: Roasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Roaster roaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateAbbrev"] = new SelectList(_context.State, "StateAbbrev", "StateAbbrev", roaster.StateAbbrev);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", roaster.UserId);
            return View(roaster);
        }

        // GET: Roasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roaster = await _context.Roaster.FindAsync(id);
            if (roaster == null)
            {
                return NotFound();
            }
            ViewData["StateAbbrev"] = new SelectList(_context.State, "StateAbbrev", "StateAbbrev", roaster.StateAbbrev);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", roaster.UserId);
            return View(roaster);
        }

        // POST: Roasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoasterId,UserId,Name,City,StateAbbrev,ImagePath")] Roaster roaster)
        {
            if (id != roaster.RoasterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoasterExists(roaster.RoasterId))
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
            ViewData["StateAbbrev"] = new SelectList(_context.State, "StateAbbrev", "StateAbbrev", roaster.StateAbbrev);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", roaster.UserId);
            return View(roaster);
        }

        // GET: Roasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roaster = await _context.Roaster
                .Include(r => r.State)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RoasterId == id);
            if (roaster == null)
            {
                return NotFound();
            }

            return View(roaster);
        }

        // POST: Roasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roaster = await _context.Roaster.FindAsync(id);
            _context.Roaster.Remove(roaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoasterExists(int id)
        {
            return _context.Roaster.Any(e => e.RoasterId == id);
        }
    }
}
