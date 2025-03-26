using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripOrganization.Data;
using TripOrganization.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripOrganization.Controllers
{
    [Authorize]
    public class TripsController : Controller
    {
        private readonly UserManager<IdentityUser>_userManager;
        private readonly ApplicationDbContext _context;

        public TripsController(ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            string userId= user.Id;
            ViewBag.UserId = userId; 
            return View(await _context.Trip.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(User);
            string userId= user.Id;
            ViewBag.UserId = userId; 
            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Capacity,Data,Cost,Date")] Trip trip)
        {
            var user = await _userManager.GetUserAsync(User);

            trip.OwnerId = user.Id;

            ModelState.Remove(nameof(trip.OwnerId));

            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(User);
            string userId= user.Id;
            ViewBag.UserId = userId; 
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Capacity,Data,Cost,Date")] Trip updatedTrip)
        {
            if (id != updatedTrip.Id)
            {
                return NotFound();
            }
            var trip = await _context.Trip.FindAsync(id);
            var user = await _userManager.GetUserAsync(User);
            if (user == null || trip.OwnerId != user.Id)
            {
                return Unauthorized();
            }
            ModelState.Remove(nameof(trip.OwnerId));


            if (ModelState.IsValid)
            {
                try
                {
                    if (trip == null)
                    {
                        return NotFound();
                    }
                    
                    trip.Title = updatedTrip.Title;
                    trip.Capacity = updatedTrip.Capacity;
                    trip.Data = updatedTrip.Data;
                    trip.Cost = updatedTrip.Cost;
                    trip.Date = updatedTrip.Date;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(updatedTrip.Id))
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
            return View(updatedTrip);
        }


        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var existingTrip = await _context.Trip.FindAsync(id);
            var user = await _userManager.GetUserAsync(User);

            if(existingTrip.OwnerId != user.Id)
            {
                return Unauthorized();
            }

            if (existingTrip != null)
            {
                _context.Trip.Remove(existingTrip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trip.Any(e => e.Id == id);
        }
    }
}
