using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Controllers
{
    public class DemonstrationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DemonstrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Demonstrations
        public async Task<IActionResult> Index()
        {
          
            return View(await _context.Demonstration.ToListAsync());
        }

        // GET: Demonstrations/Details/5
        public async Task<IActionResult> Details(int? id, int? homeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var home = from t in _context.Homes
                       where t.HomeId == homeId
                       select t.FullAddress.ToString();
            ViewBag.home = home;
            var demonstration = await _context.Demonstration
                .FirstOrDefaultAsync(m => m.DemonstrationId == id);
            if (demonstration == null)
            {
                return NotFound();
            }

            return View(demonstration);
        }

        // GET: Demonstrations/Create
        public IActionResult Create()
        {
            ViewBag.Homes = new SelectList(_context.Homes, "HomeId", "FullAddress");
            return View();
        }

        // POST: Demonstrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DemonstrationId,BookingTime,BookingDate,HomeId")] Demonstration demonstration)
        {
            ViewBag.Homes = new SelectList(_context.Homes, "HomeId", "FullAddress");
            if (ModelState.IsValid)
            {
                _context.Add(demonstration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demonstration);
        }

        // GET: Demonstrations/Edit/5
        public async Task<IActionResult> Edit(int? id, int? homeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var home = from t in _context.Homes
                       where t.HomeId == homeId
                       select t.FullAddress.ToString();
            ViewBag.home = home;
            var demonstration = await _context.Demonstration.FindAsync(id);
            if (demonstration == null)
            {
                return NotFound();
            }
            return View(demonstration);
        }

        // POST: Demonstrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DemonstrationId,BookingTime,BookingDate,FirstName,LastName,Street,City,PostalCode,District,PhoneNUmber,Email,HomeId")] Demonstration demonstration)
        {
            if (id != demonstration.DemonstrationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demonstration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemonstrationExists(demonstration.DemonstrationId))
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
            return View(demonstration);
        }

        // GET: Demonstrations/Delete/5
        public async Task<IActionResult> Delete(int? id, int? homeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var home = from t in _context.Homes
                       where t.HomeId == homeId
                       select t.FullAddress.ToString();
            ViewBag.home = home;

            var demonstration = await _context.Demonstration
                .FirstOrDefaultAsync(m => m.DemonstrationId == id);
            if (demonstration == null)
            {
                return NotFound();
            }

            return View(demonstration);
        }

        // POST: Demonstrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demonstration = await _context.Demonstration.FindAsync(id);
            _context.Demonstration.Remove(demonstration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemonstrationExists(int id)
        {
            return _context.Demonstration.Any(e => e.DemonstrationId == id);
        }
    }
}
