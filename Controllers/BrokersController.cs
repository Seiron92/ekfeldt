using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;
using project.ViewModels;

namespace project.Controllers
{
    public class BrokersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public BrokersController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Brokers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Broker.ToListAsync());
        }

      

        // GET: Brokers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brokers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrokerId,FirstName,LastName,Email,Phonenumber,Image,ImageText,HomeId, Title")] Broker broker, bool HeroImage2, BrokersViewModel model)
        {
            if (ModelState.IsValid)
            {



                //en bild
                string uniqueFileName = null;
                if (model.Photo != null)

                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                    
                    broker.Image = uniqueFileName;
                }


            




                _context.Add(broker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(broker);
        }

        // GET: Brokers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var broker = await _context.Broker.FindAsync(id);
            if (broker == null)
            {
                return NotFound();
            }
            return View(broker);
        }

        // POST: Brokers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrokerId,FirstName,LastName,Email,Phonenumber,Image,ImageText,HomeId, Title")] Broker broker, BrokersViewModel model)
        {
            if (id != broker.BrokerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    //en bild
                    string uniqueFileName = null;
                    if (model.Photo != null)

                   {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                        /*
                                                Broker img = new Broker();
                                                img.ImageText = uniqueFileName;
                                                img.Image = uniqueFileName;


                                                _context.Update(img);
                                                */
                        broker.Image = uniqueFileName;
                    }

                 
                    _context.Update(broker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrokerExists(broker.BrokerId))
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
            return View(broker);
        }

        // GET: Brokers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var broker = await _context.Broker
                .FirstOrDefaultAsync(m => m.BrokerId == id);
            if (broker == null)
            {
                return NotFound();
            }

            return View(broker);
        }

        // POST: Brokers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var broker = await _context.Broker.FindAsync(id);
            _context.Broker.Remove(broker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrokerExists(int id)
        {
            return _context.Broker.Any(e => e.BrokerId == id);
        }
    }
}
