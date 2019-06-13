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
            var applicationDbContext = _context.Roaster.Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Roasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roaster = await _context.Roaster
                .Include(r => r.User)
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Roasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoasterId,UserId,Name,City,State,ImagePath")] Roaster roaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", roaster.UserId);
            return View(roaster);
        }

        // POST: Roasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoasterId,UserId,Name,City,State,ImagePath")] Roaster roaster)
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
