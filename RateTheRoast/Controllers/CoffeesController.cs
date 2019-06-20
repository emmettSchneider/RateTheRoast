using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using RateTheRoast.Data;
using RateTheRoast.Models;
using RateTheRoast.Models.ViewModels;

namespace RateTheRoast.Views
{
    public class CoffeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CoffeesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Coffees
        public async Task<IActionResult> Index(string SearchString)
        {
            ViewBag.SearchString = false;

            if (SearchString != null)
            {

                var applicationDbContext = _context.Coffee.Include(r => r.Roaster).Include(ri => ri.RoastIntensity)

                   .Where(c => c.Name.Contains(SearchString) || c.Roaster.Name.Contains(SearchString)
                   || c.Roaster.City.Contains(SearchString))

                   .OrderByDescending(c => c.Name);
                ViewBag.SearchString = true;
                return View(await applicationDbContext.ToListAsync());
            }
            // if the search bar is blank the complete list of products will be returned to the user
            else
            {
                var applicationDbContext = _context.Coffee
                    .OrderByDescending(c => c.DateAdded).Take(20);

                return View(await applicationDbContext.ToListAsync());
            }

        }

        // GET: Coffees/Details/5
        public async Task<IActionResult> Reviews(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loggedInUser = await GetCurrentUserAsync();

            var coffee = await _context.Coffee
                .Include(c => c.RoastIntensity)
                .Include(c => c.Roaster)
                .Include(c => c.Reviews).ThenInclude(c => c.BrewMethod)
                .Include(c => c.Reviews).ThenInclude(c => c.User)
                .Include(c => c.Reviews).ThenInclude(c => c.State)
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
