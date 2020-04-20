﻿using System;
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
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kitchen
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RoomBookings.Include(r => r.Room);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Kitchen/Details/5
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

        // GET: Kitchen/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId");
            return View();
        }

        // POST: Kitchen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,Date,NumOfChildrenInRoom,NumOfAdultsInRoom,NumberOfChildBreakfastReservations,NumberOfAdultBreakfastReservations,NumberOfChildrenCheckedInToBreakfast,NumberOfAdultsCheckedInToBreakfast,RoomId")] RoomBooking roomBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "RoomNumber", "RoomNumber", roomBooking.RoomNumber);
            return View(roomBooking);
        }

        // GET: Kitchen/Edit/5
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
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "RoomId", roomBooking.RoomId);
            return View(roomBooking);
        }

        // POST: Kitchen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,Date,NumOfChildrenInRoom,NumOfAdultsInRoom,NumberOfChildBreakfastReservations,NumberOfAdultBreakfastReservations,NumberOfChildrenCheckedInToBreakfast,NumberOfAdultsCheckedInToBreakfast,RoomId")] RoomBooking roomBooking)
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
            ViewData["RoomNumber"] = new SelectList(_context.Rooms, "RoomId", "RoomId", roomBooking.RoomId);
            return View(roomBooking);
        }

        // GET: Kitchen/Delete/5
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

        // POST: Kitchen/Delete/5
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
