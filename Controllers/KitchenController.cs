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
    [Authorize(Policy = "KitchenAccess")]
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Kitchen//
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RoomBookings.Include(r => r.Room);
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
