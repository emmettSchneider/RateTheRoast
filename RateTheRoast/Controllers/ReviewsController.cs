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
    public class ReviewsController : Controller
        
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Review.Include(r => r.BrewMethod).Include(r => r.Coffee).Include(r => r.Location).Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .Include(r => r.BrewMethod)
                .Include(r => r.Coffee)
                .Include(r => r.Location)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Add
        public IActionResult Add(int id)
        {
            CoffeeViewModel coffeeViewModel = new CoffeeViewModel
            {
                Coffee = _context.Coffee.Find(id)
            };
            ViewData["BrewMethodId"] = new SelectList(_context.BrewMethod, "BrewMethodId", "Method");
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "Name");

            return View(coffeeViewModel);
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CoffeeViewModel newReview)
        {
            

            var returnToCoffee = newReview.Review.CoffeeId;
            var loggedInUser = await GetCurrentUserAsync();

            ModelState.Remove("ReviewId");
            ModelState.Remove("Review.UserId");

            if (ModelState.IsValid)
            {
                newReview.Review.UserId = loggedInUser.Id;
                _context.Add(newReview.Review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Reviews", "Coffees", new { id = returnToCoffee });
            }
            ViewData["BrewMethodId"] = new SelectList(_context.BrewMethod, "BrewMethodId", "Method", newReview.Review.BrewMethodId);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "Name", newReview.Review.LocationId);
            return View(newReview);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["BrewMethodId"] = new SelectList(_context.BrewMethod, "BrewMethodId", "Method", review.BrewMethodId);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "Name", review.LocationId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewId,CoffeeId,UserId,DateCreated,DateEdited,BrewMethodId,Price,LocationId,Narrative,Score")] Review review)
        {
            if (id != review.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Reviews", "Coffees", new { id = review.CoffeeId });
            }
            ViewData["BrewMethodId"] = new SelectList(_context.BrewMethod, "BrewMethodId", "Method", review.BrewMethodId);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "Name", review.LocationId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .Include(r => r.BrewMethod)
                .Include(r => r.Coffee)
                .Include(r => r.Location)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Review.FindAsync(id);
            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction("Reviews", "Coffees", new { id = review.CoffeeId });
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.ReviewId == id);
        }
    }
}
