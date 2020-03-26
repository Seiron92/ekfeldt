using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Controllers
{

        public class PersonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Persons
        public async Task<IActionResult> Index(int? homeId)
        {
            var demos = _context.Persons;
            List<Persons> pers = new List<Persons>();

            if (homeId != null)
            {

                foreach (var item in demos)
                {
                    if (item.HomeId == homeId && item.Viewer == true && item.deleted != true)
                    {
                        Persons person = new Persons()
                        {
                            PersonId = item.PersonId,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            PhoneNUmber = item.PhoneNUmber,
                            Email = item.Email,
                            City = item.City,
                            Street = item.Street,
                            PostalCode = item.PostalCode,
                            HomeId = item.HomeId

                        };
                        pers.Add(person);
                        ViewBag.demosControll = 1;
                        ViewBag.persons = pers;
                    }

                }
                // GET OBJECT ADDRESS
                var home = from t in _context.Homes
                           where t.HomeId == homeId
                           select t.FullAddress.ToString();
                ViewBag.home = home;
            }

            return View(await _context.Persons.ToListAsync());
        }
        public async Task<IActionResult> BidderIndex(int? homeId)
        {
            var demos = _context.Persons;
            List<Persons> pers = new List<Persons>();

            if (homeId != null)
            {

                foreach (var item in demos)
                {
                    if (item.HomeId == homeId && item.Bidder == true && item.deleted != true)
                    {
                        Persons person = new Persons()
                        {
                            PersonId = item.PersonId,
                            FirstName = item.FullName,
                            LastName = item.LastName,
                            PhoneNUmber = item.PhoneNUmber,
                            Email = item.Email,
                            City = item.City,
                            Street = item.Street,
                            PostalCode = item.PostalCode,
                            HomeId = item.HomeId,
                            Amount = item.Amount,
                            Date = item.Date,
                            Time = item.Time

                        };
                        pers.Add(person);
                        ViewBag.demosControll = 1;

             
                    }

                }
            }
            // GET OBJECT ADDRESS
            var home = from t in _context.Homes
                       where t.HomeId == homeId
                       select t.FullAddress.ToString();
            ViewBag.home = home;

            ViewBag.homeId = homeId;
            // CHANGE ORDER ON "INDEXOUTPUT" - HIGHEST BID FIRST

            ViewBag.persons = pers.OrderByDescending(x => x.Amount).ToList();
            return View(await _context.Persons.ToListAsync());
        }

        // GET: Persons/Details/5
        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id, int? demoId, int? HomeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            
         var demos = _context.Demonstration;
            List<Demonstration> Demonstrations = new List<Demonstration>();
            foreach (var item in demos)
            {
                if (item.DemonstrationId == demoId)
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

            var home = from t in _context.Homes
                       where t.HomeId == HomeId
                       select t.FullAddress.ToString();
            ViewBag.home = home;

            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }


        // GET: Persons/Create
        public IActionResult Create(int? homeId)
        {


            ViewBag.HomeId = homeId;
            ViewBag.homes = new SelectList(_context.Homes, "HomeId", "FullAddress");
            return View();
        }
        public IActionResult CreateBidder(int? homeId, int biddingId)
        {
            var person = _context.Persons;
            List<Persons> persons = new List<Persons>();
            foreach (var item in person)
            {
                if (item.Bidder == true && item.PostalCode != null && item.HomeId == homeId)
                {

                    Persons pers = new Persons()
                    {
                        FirstName = item.FullName,
                        PersonId = item.PersonId


                    };
                    persons.Add(pers);

                }

            }

          
         int? highest = 0;
        
           

            if (_context.Persons.Any(u => u.Amount >= 1))
            {
                highest = (from t in _context.Persons
                           where t.HomeId == homeId

                           select t.Amount).Max();
                int high = Convert.ToInt32(highest);
                ViewBag.high = high;
                if(highest == null)
                {
                    int highests2 = 1;
                    ViewBag.high = highests2;
                }
            }
   

 
            ViewBag.persons = persons;


            ViewBag.homeId = homeId;
            ViewBag.biddingId = biddingId;
            ViewBag.homes = new SelectList(_context.Homes, "HomeId", "FullAddress");
            return View();
        }


        // POST: Persons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FirstName,LastName,Street,City,PostalCode,Bidder,Viewer,PhoneNUmber,BiddingId, Email")] Persons persons, int DemonstrationId)
        {
       
            string HomeIdt = Request.Form["HomeId"];
            int RealHomeId = Convert.ToInt32(HomeIdt);
            string BrokId = Request.Form["BrokId"];
            int RealBrokerId = Convert.ToInt32(BrokId);
            if (ModelState.IsValid)
            {

                persons.DemonstrationId = DemonstrationId;
                persons.HomeId = RealHomeId;


                _context.Add(persons);
                await _context.SaveChangesAsync();
                ViewBag.msg = "<b>Tack för din anmälan, vi ses på visningen!</b>";
                return Redirect("/Home/Details/" + RealHomeId + "?BrokerId=" + RealBrokerId + "#visning");
            }
            
            return Redirect("/Home/Details/" + RealHomeId + "?BrokerId=" + RealBrokerId +"#visning");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> CreateViewer([Bind("PersonId,FirstName,LastName,Street,City,PostalCode,Bidder,Viewer,PhoneNUmber,BiddingId, Email")] Persons persons, int DemonstrationId)
        {

            string HomeIdt = Request.Form["HomeId"];
            int RealHomeId = Convert.ToInt32(HomeIdt);
         
            if (ModelState.IsValid)
            {

                persons.DemonstrationId = DemonstrationId;
                persons.HomeId = RealHomeId;


                _context.Add(persons);
                await _context.SaveChangesAsync();
                ViewBag.msg = "<b>Tack för din anmälan, vi ses på visningen!</b>";
                return Redirect("/Persons?homeId=" + RealHomeId);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBidder([Bind("PersonId,FirstName,LastName,Street,City,PostalCode,Bidder,Viewer,PhoneNUmber,BiddingId, Email, Amount, Date, Time, BiddingIds")] Persons persons, int DemonstrationId, int BiddingIds, int homeId, int? amount, DateTime date, DateTime time, string FirstName, string LastName, string Street, string City, string PostalCode, string PhoneNUmber, string Email)
        {

            string HomeIdt = Request.Form["HomeId"];
            int RealHomeId = Convert.ToInt32(HomeIdt);
  
            if (ModelState.IsValid)
            {

                string pers = Request.Form["persons"];
                int persConv = Convert.ToInt32(pers);

                if (pers != "0")
                {

                    var fname = from t in _context.Persons
                                where t.PersonId == persConv
                                select t.FirstName;
                    foreach(var item in fname)
                    {
                        var fnamex = item;
                       string fnames = fnamex.ToString();
                        persons.FirstName = fnames;
                    }
                    var lname = from t in _context.Persons
                                where t.PersonId == persConv
                                select t.LastName;
                    foreach(var ite in lname)
                    {
                        var lnamex = ite;
                        string lnames = lnamex.ToString();
                        persons.LastName = lnames;
                    }
                
                    var email = from t in _context.Persons
                                where t.PersonId == persConv
                                select t.Email;
                    foreach (var it in email)
                    {
                        var emailx = it;
                        string emails = emailx.ToString();
                        persons.Email = emails;

                    }
                      
                    var phone = from t in _context.Persons
                                where t.PersonId == persConv
                                select t.PhoneNUmber;
                    foreach (var i in phone)
                    {
                        var phonex = i;
                        string phones = phonex.ToString();

                        persons.PhoneNUmber = phones;
                    }
                    var alias = from t in _context.Persons
                                where t.PersonId == persConv
                                select t.Alias;
                    foreach (var i in alias)
                    {
                        var aliasx = i;
                      

                        persons.Alias = aliasx;
                    }

                    persons.Amount = amount;
                    persons.Date = date;
                    persons.Time = time;
                    persons.BiddingIds = BiddingIds;
                    persons.HomeId = homeId;
                    persons.Bidder = true;
                  


                }
                else
                {
                    int maxId = 0;



                    if (_context.Persons.Any(u => u.Alias >= 1))
                    {
                        maxId = (from c in _context.Persons where c.HomeId == homeId select c.Alias).Max();
                    }
                    else
                    {
                        maxId = 0;
                    }



                    int newId = maxId + 1;
                    persons.FirstName = FirstName; 
                    persons.LastName = LastName;
                    persons.Email = Email;
                    persons.PhoneNUmber = PhoneNUmber;
                    persons.City = City;
                    persons.Street = Street;
                    persons.PostalCode = PostalCode;
                    persons.Amount = amount;
                    persons.Date = date;
                    persons.Time = time;
                    persons.BiddingIds = BiddingIds;
                    persons.HomeId = homeId;
                    persons.Bidder = true;
                    persons.Alias = newId;
                }


                _context.Add(persons);
                await _context.SaveChangesAsync();
              
                return Redirect("/Biddings/Index");
            }

            var person = _context.Persons;
            List<Persons> persons2 = new List<Persons>();
            foreach (var item in person)
            {
                if (item.Bidder == true)
                {

                    Persons pers = new Persons()
                    {
                        FirstName = item.FullName,
                        PersonId = item.PersonId


                    };
                    persons2.Add(pers);

                }

            }

            ViewBag.persons = persons2;
            return Redirect("/Persons/CreateBidder?" + RealHomeId + "&biddingId=" + BiddingIds);
        }


        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit(int? id, int? HomeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var demos = _context.Demonstration;
            List<Demonstration> Demonstrations = new List<Demonstration>();
            foreach (var item in demos)
            {
                if (item.HomeId == HomeId)
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

            var home = from t in _context.Homes
                       where t.HomeId == HomeId
                       select t.FullAddress.ToString();
            ViewBag.home = home;

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }


        // POST: Persons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,FirstName,LastName,Street,City,PostalCode,Bidder,Viewer,PhoneNUmber, Email, HomeId, BiddingId, DemonstrationId")] Persons persons, int? HomeId)
        {
            if (id != persons.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(persons.PersonId))
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
            return View(persons);
        }

        // GET: Persons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int homeId)
        {
            var person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
          //  return RedirectToAction(nameof(Index));
            return Redirect("/Biddings");
        }
        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.PersonId == id);
        }
    }
}