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
    public class BiddingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BiddingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Biddings
        public async Task<IActionResult> Index()
        {
         
            // GET HIGHEST BIDS FOR EVERY BIDDABLE (TRUE) HOMES

            var q = (from s in _context.Persons
                     where s.Bidder == true
                    group s by s.HomeId into g
                    select new { Amount = g.Max(s => s.Amount) }).ToList();

            // SAVE AMOUNT IN LIST
            List<int> intList = new List<int>();
            foreach (var item in q)
            {
                int sum = Convert.ToInt32(item.Amount);
                intList.Add(sum);
            }
            // STORE AMOUNTLIST IN VIEWBAG
            ViewBag.sum = intList;

// ORDER "INDEX-OUTPUT" BY HOMEID
            var bid = _context.Bidding;
            var bids = from t in bid
                       orderby t.HomeId
                       select t;
            // Get all addresses
            var home = from t in _context.Homes
                       where t.Bidding == true
                       orderby t.HomeId
                       select t.FullAddress.ToString();
            ViewBag.home = home;

            return View(await bids.ToListAsync());
        }

        // GET: Biddings/Details/5
        public async Task<IActionResult> Details(int? id, int? homeId)
        {
            if (id == null)
            {
                return NotFound();
            }


            var demos = _context.Persons;
            List<Persons> pers = new List<Persons>();

            foreach (var item in demos)
            {
                if (item.BiddingIds == id && item.deleted != true)
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
                  
                    ViewBag.persons = pers;
                }

            }

            var home = from t in _context.Homes
                       where t.HomeId == homeId
                       select t.FullAddress.ToString();
            ViewBag.home = home;

            var bidding = await _context.Bidding
                .FirstOrDefaultAsync(m => m.BiddingId == id);
            if (bidding == null)
            {
                return NotFound();
            }

            return View(bidding);
        }

        // GET: Biddings/Create
        public IActionResult Create()
        {
            var homes = _context.Homes;
            List<Homes> BiddableHomes = new List<Homes>();
            foreach (var item in homes)
            {
                if (item.Bidding == false)
                {

                    Homes home = new Homes()
                    {
                        Street = item.FullAddress,
                        HomeId = item.HomeId,


                    };
                    BiddableHomes.Add(home);

                }

            }


          
            ViewBag.homes = BiddableHomes;
          
            return View();
        }

        // POST: Biddings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiddingId,Amount,Date,Time,HomeId")] Bidding bidding, int HomeId, string FirstName, string LastName, string Street, string City, string PostalCode, string PhoneNUmber, string Email)
        {
            if (ModelState.IsValid)
            {


                int maxId = 0;

                int? bmaxId = 0;

                if (_context.Persons.Any(u => u.PersonId >= 1)) {
                     maxId = (from c in _context.Persons select c.PersonId).Max();
                }
                else
                {
                    maxId = 0;
                }

                if (_context.Persons.Any(u => u.BiddingIds >= 1))
                {
                    bmaxId = (from c in _context.Persons select c.BiddingIds).Max();
                }
                else
                {
                    bmaxId = 0;
                }
                // ADD NEW PERSON
                int newId = maxId + 1;
                int? newId2 = bmaxId + 1;
                Persons pers = new Persons();
                pers.FirstName = FirstName;
                pers.LastName = LastName;
                pers.Street = Street;
                pers.City = City;
                pers.PostalCode = PostalCode;
                pers.PhoneNUmber = PhoneNUmber;
                pers.Email = Email;
                pers.Bidder = true;
             
                pers.HomeId = HomeId;

                _context.Add(pers);

                // UPDATE HOME BIDDING STATUS
               
                var query = (from q in _context.Homes
                             where q.HomeId == HomeId
                             select q).First();
                query.Bidding = true;
                _context.Homes.Update(query);

               

                _context.Add(bidding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.homes = new SelectList(_context.Homes, "HomeId", "FullAddress");
            return View(bidding);
        }

        // GET: Biddings/Edit/5
        public async Task<IActionResult> Edit(int? id, int? homeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var demos = _context.Persons;
            List<Persons> pers = new List<Persons>();

            foreach (var item in demos)
            {
                if (item.BiddingIds == id && item.deleted != true)
                {
                    Persons person = new Persons()
                    {
                    
                        FirstName = item.FirstName,
         

                    };
                    pers.Add(person);

                    ViewBag.persons = pers;
                }

            }
            var home = from t in _context.Homes
                       where t.HomeId == homeId
                       select t.FullAddress.ToString();
            ViewBag.home = home;
            var bidding = await _context.Bidding.FindAsync(id);
            if (bidding == null)
            {
                return NotFound();
            }

            return View(bidding);
        }

        // POST: Biddings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BiddingId,BidderId,Amount,Date,Time,FirstName,LastName,Street,City,PostalCode,District,PhoneNUmber,Email,HomeId")] Bidding bidding)
        {
            if (id != bidding.BiddingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bidding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiddingExists(bidding.BiddingId))
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
            return View(bidding);
        }

        // GET: Biddings/Delete/5
        public async Task<IActionResult> Delete(int? id, int homeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.homeId = homeId;

            var bidding = await _context.Bidding
                .FirstOrDefaultAsync(m => m.BiddingId == id);
            if (bidding == null)
            {
                return NotFound();
            }

            return View(bidding);
        }

        // POST: Biddings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int homeId)
        {
            int maxId = 0;



            if (_context.Persons.Any(u => u.HomeId >= 1))
            {
                maxId = (from c in _context.Persons select c.PersonId).Max();
            }
            else
            {
                maxId = 0;
            }
            // UPDATE HOME BIDDING STATUS

            var query = (from q in _context.Homes
                         where q.HomeId == homeId
                         select q).First();
            query.Bidding = false;
            _context.Homes.Update(query);

        

            var bidding = await _context.Bidding.FindAsync(id);
            _context.Bidding.Remove(bidding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiddingExists(int id)
        {
            return _context.Bidding.Any(e => e.BiddingId == id);
        }
    }
}
