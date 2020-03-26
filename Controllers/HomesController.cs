using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using project.ViewModels;

namespace project.Controllers
{
    public class HomesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomesController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }


        // GET: Homes
        [Authorize]
        public async Task<IActionResult> Index()
        {

            return View(await _context.Homes.ToListAsync());

        }

        // GET: Homes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id, int BrokerId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.BrokId = BrokerId;

            /* IMAGES */
            var getImages = _context.Image;
            // ALL REGULAR IMAGES

            List<Image> HomeImage = new List<Image>();
            foreach (var item in getImages)
            {
                if (item.HomeIds == id)
                {
                    if (item.HeroImage != true && item.FloorPlan != "true")
                    {
                        Image imgs = new Image()
                        {
                            ImageText = item.ImageText,
                            ImageAdress = item.ImageAdress,
                            ImageId = item.ImageId

                        };
                        HomeImage.Add(imgs);
                    }
                }
            }

            ViewBag.HomeImg = HomeImage;
            

            // HERO IMAGE
           List<Image> HeroImages = new List<Image>();
            foreach (var item in getImages)
            {
                if (item.HomeIds == id && item.HeroImage == true)
                {
                    Image Herimgs = new Image()
                    {
                        ImageText = item.ImageText,
                        ImageAdress = item.ImageAdress,
                        ImageId = item.ImageId
                    };
                    HeroImages.Add(Herimgs);
                }
            }
            ViewBag.HeroImages = HeroImages;
            

            // ALL FLOORPLANS
            List<Image> Planritning = new List<Image>();
            foreach (var item in getImages)
            {
                if (item.HomeIds == id)
                {
                    if (item.FloorPlan == "true")
                    {
                        Image imgs = new Image()
                        {
                            ImageText = item.ImageText,
                            ImageAdress = item.ImageAdress,
                            ImageId = item.ImageId

                        };
                        Planritning.Add(imgs);
                    }
                }
            }
            ViewBag.Planritning = Planritning;
            // BROKERS

            var brokers = _context.Broker;
            List<Broker> Brokers = new List<Broker>();
            foreach (var item in brokers)
            {
                if (BrokerId == item.BrokerId)
                {
                    Broker brok = new Broker()
                    {
                        BrokerId = item.BrokerId,
                        FirstName = item.fullname,
                        Phonenumber = item.Phonenumber,
                        Email = item.Email,
                        Title = item.Title,
                        Image = item.Image
                    };
                    Brokers.Add(brok);
                }
            }
            ViewBag.BrokerList = Brokers;



            var homes = await _context.Homes
                .FirstOrDefaultAsync(m => m.HomeId == id);
            if (homes == null)
            {
                return NotFound();
            }

            return View(homes);
        }

        // GET: Homes/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.BrokersId = new SelectList(_context.Broker, "BrokerId", "fullname");
            return View();
        }


        // POST: Homes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomeId,PublishDate,Type,Street,City,County,PostalCode,District Room,AppartmentNumber,Society,Floor,Elevator,Dop,Price,Bidding,HomeType,Tow,LivingArea,BiArea,GardenArea,Floor,BuildningSystem,Renovations,OtherBuildnings,LivingSpaceComment,Parking,TvInternet,HeatVentilation,BuildningYear,MounthlyFee,PartOfSociety,PawnBroking,AboutSociety,CommonAreas,TransactionFee,TransactionFeePaidBy,OperationCost,TypeCode,TaxValue,TaxValueProperty,TaxValueLand,TaxYear,PawnLetters,Heating,PowerComsumption,EnergyCosts,NumberOfOccupants,WaterAndSewedge,Cleaning,Insurance,InsuranceComment,EnergyDeclaration,EnergyPerfomance,EnergyClass,SpecificEnergyUsage,DeclarationDate,Inspector,SummaryHeading,Summary,Information, OtherRightsAndLiabilities")]Homes homes, string ImageText2, bool HeroImage2, HomesCreateViewModel model, int Brokers)
        {
   
            if (ModelState.IsValid)
            {

                // GET "HomeId" to use for the images 
                int maxId = 0;

                if (_context.Homes.Any(u => u.HomeId >= 1)) // I ANY HOMES EXISTS 
                {
                    maxId = (from c in _context.Homes select c.HomeId).Max(); // GET HIGHEST ID
                }
                else
                {
                    maxId = 0; // IF NO HOMES EXISTS, DECLARE maxID TO 0
                }

                int newId = maxId + 1; // ADD 1 

                //ONE IMAGE
                string uniqueFileName = null;
                string uniqueFileNames = null;
                if (model.Photo != null)

                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileNames = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileNames);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));


                    Image img = new Image();
                    img.ImageText = ImageText2;
                    img.ImageAdress = uniqueFileNames;
                    img.HeroImage = HeroImage2;
                    img.FloorPlan = "false";
                    img.HomeIds = newId;

                    _context.Add(img);
                }


                int i = 0;
                int k = 0;

                //MULTIPLE IMAGES

                if (model.Photos != null && model.Photos.Count > 0)
                {

                    foreach (IFormFile photo in model.Photos)
                    {


                        int b = i++;
                        int c = k++;

                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));


                        Image img = new Image();
                        string formInput = Request.Form["Multiple"];
                        string[] imgText = formInput.Split(',');


                        string formInput2 = Request.Form["Floorplan3"];
                        //
                        string[] floorplans = formInput2.Split(',');

                        img.ImageText = imgText[b];
                        img.ImageAdress = uniqueFileName;
                        img.HeroImage = false;
                        img.FloorPlan = floorplans[c];
                        img.HomeIds = newId;

                        _context.Add(img);

                    }
                }
                homes.deleted = false;
                homes.ImageAddress = uniqueFileNames;
                homes.BrokerId = Brokers;
                _context.Add(homes);


                ViewBag.BrokersId = new SelectList(_context.Broker, "BrokerId", "fullname");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //  return View(model);
            }
            ViewBag.BrokersId = new SelectList(_context.Broker, "BrokerId", "fullname");
            return View(model);
        }

        // GET: Homes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id, HomesCreateViewModel test)
        {
            if (id == null)
            {
                return NotFound();
            }
            var getImages = _context.Image;
            // HERO IMAGE
            List<Image> HeroImages = new List<Image>();
            foreach (var item in getImages)
            {
                if (item.HomeIds == id && item.HeroImage == true)
                {
                    Image Herimgs = new Image()
                    {
                        ImageText = item.ImageText,
                        ImageAdress = item.ImageAdress,
                        ImageId = item.ImageId
                    };
                    HeroImages.Add(Herimgs);
                }
            }
            ViewBag.HeroImages = HeroImages;


            var homes = await _context.Homes.FindAsync(id);

            ViewBag.Types = new SelectList(_context.Homes, "Type", "Type");

            ViewBag.BrokersId = new SelectList(_context.Broker, "BrokerId", "fullname");


            if (homes == null)
            {
                return NotFound();
            }
         //   return View(await results.ToListAsync());
              return View(homes);
        }

        // POST: Homes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("HomeId,PublishDate,Type,Street,City,County,PostalCode,District,AppartmentNumber,Society,Floor,Elevator,Dop,Price,Bidding,HomeType,Tow,LivingArea,BiArea,GardenArea,BuildningSystem,Renovations,OtherBuildnings,LivingSpaceComment,Parking,TvInternet,HeatVentilation,BuildningYear,MounthlyFee,PartOfSociety,PawnBroking,AboutSociety,CommonAreas,TransactionFee,TransactionFeePaidBy,OperationCost,TypeCode,TaxValue,TaxValueProperty,TaxValueLand,TaxYear,PawnLetters,Heating,PowerComsumption,EnergyCosts,NumberOfOccupants,WaterAndSewedge,Cleaning,Insurance,InsuranceComment,EnergyDeclaration,EnergyPerfomance,EnergyClass,SpecificEnergyUsage,DeclarationDate,Inspector,SummaryHeading,Summary,OtherRightsAndLiabilities,Room, BrokerId")] Homes homes, string ImageText2, bool HeroImage2, int Brokers, HomesCreateViewModel model, string Information, string AboutSociety, string ImageAddress)
        {
            if (id != homes.HomeId)
            {
                return NotFound();
            }
            var getImages = _context.Image;
            // HERO IMAGE
            List<Image> HeroImages = new List<Image>();
            foreach (var item in getImages)
            {
                if (item.HomeIds == id && item.HeroImage == true)
                {
                    Image Herimgs = new Image()
                    {
                        ImageText = item.ImageText,
                        ImageAdress = item.ImageAdress,
                        ImageId = item.ImageId
                    };
                    HeroImages.Add(Herimgs);
                }
            }
            ViewBag.HeroImages = HeroImages;
            ViewBag.BrokersId = new SelectList(_context.Broker, "BrokerId", "fullname");

            if (ModelState.IsValid)
            {
                try
                {

                    homes.deleted = false;
                    homes.ImageAddress = ImageAddress;
                    homes.AboutSociety = AboutSociety;
                    homes.Information = Information;
                    homes.BrokerId = Brokers;
                    _context.Update(homes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomesExists(homes.HomeId))
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
            return View(homes);
        }

        // GET: Homes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id, int BrokerId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getImages = _context.Image;
            // HERO IMAGE
            List<Image> HeroImages = new List<Image>();
            foreach (var item in getImages)
            {
                if (item.HomeIds == id && item.HeroImage == true)
                {
                    Image Herimgs = new Image()
                    {
                        ImageText = item.ImageText,
                        ImageAdress = item.ImageAdress,
                        ImageId = item.ImageId
                    };
                    HeroImages.Add(Herimgs);
                }
            }
            ViewBag.HeroImages = HeroImages;

            var brokers = _context.Broker;
            List<Broker> Brokers = new List<Broker>();
            foreach (var item in brokers)
            {
                if (BrokerId == item.BrokerId)
                {
                    Broker brok = new Broker()
                    {
                        BrokerId = item.BrokerId,
                        FirstName = item.fullname,
                        Phonenumber = item.Phonenumber,
                        Email = item.Email,
                        Title = item.Title,
                        Image = item.Image
                    };
                    Brokers.Add(brok);
                }
            }
            ViewBag.BrokerList = Brokers;

            // ALL REGULAR IMAGES
            List<string> HomeImages = new List<string>();
            foreach (var item in getImages)
            {
                if (item.HomeIds == id)
                {
                    if (item.HeroImage != true && item.FloorPlan != "true")
                    {
                        HomeImages.Add(item.ImageAdress);
                    }
                }
            }

            ViewBag.HomeImages = HomeImages;
            // ALL REGULAR IMAGES TEXT
            List<string> HomeImagesText = new List<string>();
            foreach (var item in getImages)
            {
                if (item.HomeIds == id)
                {
                    if (item.HeroImage != true && item.FloorPlan != "true")
                    {
                        HomeImagesText.Add(item.ImageText);
                    }
                }
            }

            ViewBag.HomeImagesText = HomeImagesText;
            // ALL REGULAR IMAGES IDS
            List<int> HomeImagesId = new List<int>();
            foreach (var item in getImages)
            {
                if (item.HomeIds == id)
                {
                    if (item.HeroImage != true && item.FloorPlan != "true")
                    {
                        HomeImagesId.Add(item.ImageId);
                    }
                }
            }
            ViewBag.HomeImagesId = HomeImagesId;
          





            var homes = await _context.Homes
          .FirstOrDefaultAsync(m => m.HomeId == id);

       


            if (homes == null)
            {
                return NotFound();
            }

            return View(homes);
        }

        // POST: Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int maxId = 0;



            if (_context.Homes.Any(u => u.HomeId >= 1))
            {
                maxId = (from c in _context.Homes select c.HomeId).Max();
            }
            else
            {
                maxId = 0;
            }
            /* Get all homes where status-deleted is true */
            var deletedHomes = from t in _context.Homes
                                     where t.deleted == true && maxId != id
                                     select t.HomeId;

            /* DELETE IMAGE*/
            var deleteImage = from t in _context.Image
                           where t.HomeIds == id
                           select t.ImageId;
            var deleteImageAddress = from t in _context.Image
                                     where t.HomeIds == id
                                     select t.ImageAdress;
            string imgAddress = null;
            string folder = Path.Combine(hostingEnvironment.WebRootPath, "images");
           

            foreach (var item in deleteImageAddress)
            {
                imgAddress = item;
                string paths = Path.Combine(folder, imgAddress);
                System.IO.File.Delete(paths);
            }
            /* DELETE IMAGE FROM IMAGE TABEL */
            foreach (int item in deleteImage)
            {
                var img = await _context.Image.FindAsync(item);
                _context.Image.Remove(img);

            }


            var homes = await _context.Homes.FindAsync(id);
      
            // IF NOT HIGHETS HOMEID, DELETE, IF HIGHEST UPDATE "deleted-status" TO TRUE
            if (id == maxId)
            {
                homes.deleted = true;

                _context.Update(homes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

              
            }else
            {
                // remove "old" deleted homes
                
                foreach (var item in _context.Homes)
                {
                    if(item.deleted == true && maxId != id)
                    {
                        _context.Homes.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                 
                }
                
                    _context.Homes.Remove(homes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


        
        }

        private bool HomesExists(int id)
        {
            return _context.Homes.Any(e => e.HomeId == id);
        }
    }
}
