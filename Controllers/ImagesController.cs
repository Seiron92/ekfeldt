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

using System.Drawing;

namespace project.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ImagesController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Images
        public async Task<IActionResult> Index()
        {
            return View(await _context.Image.ToListAsync());
        }

        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Image
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,ImageAdress,ImageText,HeroImage,FloorPlan,HomeId")] Image image)
        {
            if (ModelState.IsValid)
            {
                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }

        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(int? id, int? BrokerId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.BrokerId = BrokerId;

            var image = await _context.Image.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,ImageAdress,ImageText,HeroImage,FloorPlan,HomeId")] Image image, Image model, string ImageText, string Floorplan)
        {

            string HomeIdt = Request.Form["HomeIdt"];
            int RealHomeId = Convert.ToInt32(HomeIdt);
            string BrokId = Request.Form["BrokId"];
            int RealBrokerId = Convert.ToInt32(BrokId);
            if (id != image.ImageId)
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
                        /* DELETE */
                        var deleteThis = image.ImageAdress;
                          string folder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                          string paths = Path.Combine(folder, deleteThis);
           

                        System.IO.File.Delete(paths);

                        /* UPDATE */
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                        image.HomeIds = RealHomeId;
                        image.FloorPlan = Floorplan;
                        image.ImageText = ImageText;
                        image.ImageAdress = uniqueFileName;
                        _context.Update(image);

                        /* update imageAddress fiels in table Homes */
                        var query = (from q in _context.Homes
                                     where q.HomeId == RealHomeId
                                     select q).First();
                        query.ImageAddress = uniqueFileName;
                        _context.Homes.Update(query);
                    }


                
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.ImageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                Response.Redirect("/Homes/Details/"+ RealHomeId+"?BrokerId=" + RealBrokerId);
            }
            return View(image);
        }

        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(int? id, int? BrokerId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.BrokerId = BrokerId;
            var image = await _context.Image
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string HomeIdt = Request.Form["HomeIdt"];
            int RealHomeId = Convert.ToInt32(HomeIdt);
            string BrokId = Request.Form["BrokId"];
            int RealBrokerId = Convert.ToInt32(BrokId);
            var image = await _context.Image.FindAsync(id);
            /* DELETE IMAGE*/
            var deleteThis = image.ImageAdress;
            string folder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            string paths = Path.Combine(folder, deleteThis);


            System.IO.File.Delete(paths);
          
            _context.Image.Remove(image);
            await _context.SaveChangesAsync();

             return Redirect("/Homes/Details/" + RealHomeId + "?BrokerId=" + RealBrokerId);
        }

        private bool ImageExists(int id)
        {
            return _context.Image.Any(e => e.ImageId == id);
        }
    }
}
