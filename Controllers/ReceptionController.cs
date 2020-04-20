using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUIEX2PROJECT.Data;
using GUIEX2PROJECT.Models;
using Microsoft.AspNetCore.Authorization;

namespace GUIEX2PROJECT.Controllers
{
    [Authorize(Policy = "ReceptionAccess")]
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
            var applicationDbContext = _context.RoomBookings.Include(r => r.Room);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reception/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBooking = await _context.RoomBookings
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (roomBooking == null)
            {
                return NotFound();
            }

            return View(roomBooking);
        }

        // GET: Reception/Create
        public IActionResult Create()
        {
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
            return View();
        }

        // POST: Reception/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,Date,NumberOfChildBreakfastReservations,NumberOfAdultBreakfastReservations,RoomNumber")] RoomBooking roomBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "RoomId", "RoomId", roomBooking.RoomNumber);
            return View(roomBooking);
        }

        // GET: Reception/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBooking = await _context.RoomBookings.FindAsync(id);
            if (roomBooking == null)
            {
                return NotFound();
            }
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "RoomId", "RoomId", roomBooking.RoomNumber);
            return View(roomBooking);
        }

        // POST: Reception/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,Date,NumberOfChildBreakfastReservations,NumberOfAdultBreakfastReservations,RoomNumber")] RoomBooking roomBooking)
        {
            if (id != roomBooking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomBookingExists(roomBooking.BookingId))
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
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "RoomId", "RoomId", roomBooking.RoomNumber);
            return View(roomBooking);
        }

        // GET: Reception/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBooking = await _context.RoomBookings
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (roomBooking == null)
            {
                return NotFound();
            }

            return View(roomBooking);
        }

        // POST: Reception/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomBooking = await _context.RoomBookings.FindAsync(id);
            _context.RoomBookings.Remove(roomBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomBookingExists(int id)
        {
            return _context.RoomBookings.Any(e => e.BookingId == id);
        }
    }
}
