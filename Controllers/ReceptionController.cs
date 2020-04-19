using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUIEX2PROJECT.Data;
using GUIEX2PROJECT.Models;

namespace GUIEX2PROJECT.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reception
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BreakfastReservations.Include(b => b.room);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reception/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastReservation = await _context.BreakfastReservations
                .Include(b => b.room)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (breakfastReservation == null)
            {
                return NotFound();
            }

            return View(breakfastReservation);
        }

        // GET: Reception/Create
        public IActionResult Create()
        {
            ViewData["roomNumber"] = new SelectList(_context.Rooms, "RoomNumber", "RoomNumber");
            return View();
        }

        // POST: Reception/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,Date,NumberOfChildReservations,NumberOfAdultReservations,NumberOfChildrenCheckedIn,NumberOfAdultsCheckedIn,roomNumber")] BreakfastReservation breakfastReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breakfastReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["roomNumber"] = new SelectList(_context.Rooms, "RoomNumber", "RoomNumber", breakfastReservation.roomNumber);
            return View(breakfastReservation);
        }

        // GET: Reception/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastReservation = await _context.BreakfastReservations.FindAsync(id);
            if (breakfastReservation == null)
            {
                return NotFound();
            }
            ViewData["roomNumber"] = new SelectList(_context.Rooms, "RoomNumber", "RoomNumber", breakfastReservation.roomNumber);
            return View(breakfastReservation);
        }

        // POST: Reception/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,Date,NumberOfChildReservations,NumberOfAdultReservations,NumberOfChildrenCheckedIn,NumberOfAdultsCheckedIn,roomNumber")] BreakfastReservation breakfastReservation)
        {
            if (id != breakfastReservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breakfastReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreakfastReservationExists(breakfastReservation.ReservationId))
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
            ViewData["roomNumber"] = new SelectList(_context.Rooms, "RoomNumber", "RoomNumber", breakfastReservation.roomNumber);
            return View(breakfastReservation);
        }

        // GET: Reception/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastReservation = await _context.BreakfastReservations
                .Include(b => b.room)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (breakfastReservation == null)
            {
                return NotFound();
            }

            return View(breakfastReservation);
        }

        // POST: Reception/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breakfastReservation = await _context.BreakfastReservations.FindAsync(id);
            _context.BreakfastReservations.Remove(breakfastReservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreakfastReservationExists(int id)
        {
            return _context.BreakfastReservations.Any(e => e.ReservationId == id);
        }
    }
}
