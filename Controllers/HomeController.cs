using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using project.Data;
using project.Helpers;
using project.Models;


namespace project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

   
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()

        {
            

            // Get brokers

            var brokers = _context.Broker;
        
            List<Broker> Brokers = new List<Broker>();
            foreach (var item in brokers)
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

            ViewBag.BrokerList = Brokers;


            // GET 2 BATCHES OF 3 LISTNINGS FOR THE STARTPAGE CAROULSEL
            var homes = _context.Homes;
            IQueryable<project.Models.Homes> firstThree = homes.OrderByDescending(t => t.PublishDate).Where(t=>t.deleted != true).Take(3);
            IQueryable<project.Models.Homes> lastThree = homes.OrderByDescending(t => t.PublishDate).Where(t => t.deleted != true).Skip(3).Take(3);
            ViewBag.firstThree = firstThree;
            ViewBag.lastThree = lastThree;

            return View(_context.Homes.ToList());
        }
        [HttpPost]
        public IActionResult Index(string Name, string PostalCode, string Street, string Email, string City, string LastName, string FirstName, string Subject)
        {
            if (ModelState.IsValid)
            {
                string content = "Name: " +Name;
                content += "<br>Gata: " + Street;
                content += "<br>Stad: " + City;
                content += "<br>Postnummer: " + PostalCode;
                content += "<br>E-post: " + Email;
               if (MailHelpers.Send(Email, "rebeccaseiron@gmail.com", Subject, content))
                {
                    ViewBag.msg = "Tack för ditt meddelande";
                    ViewBag.Section = "s2"; 
                }
                else
                {
                    ViewBag.msg = "Meddelandet kunde inte skickas";
                    ViewBag.Section = "s2";

                }
                
               

               
                ViewBag.Section = "s2";
                return Index();
            }
            // Get brokers

            var brokers = _context.Broker;

            List<Broker> Brokers = new List<Broker>();
            foreach (var item in brokers)
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

            ViewBag.BrokerList = Brokers;
            // ALL REGULAR IMAGES
            // Get hero images
            var getImages = _context.Image;
            var homes = _context.Homes;
            var last = (from c in _context.Homes select c.HomeId).Max();


            IQueryable<project.Models.Homes> firstThree = homes.OrderByDescending(t => t.PublishDate).Where(t => t.deleted != true).Take(3);
            IQueryable<project.Models.Homes> lastThree = homes.OrderByDescending(t => t.PublishDate).Where(t => t.deleted != true).Skip(3).Take(3);
            ViewBag.firstThree = firstThree;
            ViewBag.lastThree = lastThree;
            ViewBag.Section = "s2";
            return Index();
        }

        public async Task<IActionResult> Tillsalu()
        {

     
            ViewBag.district = new SelectList(_context.Homes, "County", "County");

            return View(await _context.Homes.ToListAsync());

        }
       
         

        // GET: Homes/Details/5

        public async Task<IActionResult> Details(int? id, int BrokerId)
        {
            if (id == null)
            {

             
                return NotFound();
            }



            var pers2 = _context.Persons;
            List<Persons> bids = new List<Persons>();

            foreach (var item2 in pers2)
            {


                if (item2.HomeId == id && item2.Bidder == true)
                {

                    Persons bidders = new Persons()
                    {
                        Amount = item2.Amount,
                        Date = item2.Date,
                        Alias = item2.Alias

                    };
                    bids.Add(bidders);
                }
            }
            ViewBag.bidders = bids.OrderByDescending(x => x.Amount).ToList(); ;
            ViewBag.control = 1;
            // SHOW AVALABLE DEMONSTRATIONS
            var demos = _context.Demonstration;
            List<Demonstration> Demonstrations = new List<Demonstration>();
            foreach (var item in demos)
            {
                if (item.HomeId == id)
                {
                
                        Demonstration dem = new Demonstration()
                        {
                            DemonstrationId = item.DemonstrationId,
                            BookingDate = item.BookingDate,
                            BookingTime = item.BookingTime

                        };
                        Demonstrations.Add(dem);
                    ViewBag.control = 1;
                }
               
            }

            ViewBag.demos = Demonstrations;

            // SHOW HIGHEST BID

            var highest = (from t in _context.Persons
                           where t.HomeId == id
                           select t.Amount).Max();
            ViewBag.Highest = highest;

            /* IMAGES */
            var homes = await _context.Homes
                .FirstOrDefaultAsync(m => m.HomeId == id);

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
                            ImageAdress = item.ImageAdress
                     
                        };
                        HomeImage.Add(imgs);
                    }
                }
            }

            ViewBag.HomeImg = HomeImage;

          
            // HERO IMAGE
            List<string> HeroImages = new List<string>();
            foreach (var item in getImages)
            {
                if (item.HomeIds == id && item.HeroImage == true)
                {
                    HeroImages.Add(item.ImageAdress);
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
                            ImageAdress = item.ImageAdress

                        };
                        Planritning.Add(imgs);
                    }
                }
            }
            ViewBag.Planritning = Planritning;


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

            if (homes == null)
            {
                return NotFound();
            }

            return View(homes);
        }




        public IActionResult Kopa()
        {
            return View();
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
