using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HomesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HomesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homes>>> GetHomes()
        {
            return await _context.Homes.ToListAsync();
        }

        // GET: api/HomesApi/5
       //   [HttpGet("{id}")]
          public async Task<ActionResult<Homes>> GetHomes(int id)
          {
              var homes = await _context.Homes.FindAsync(id);

              if (homes == null)
              {
                  return NotFound();
              }

              return homes;
          }
        // GET: api/HomesApi/&type=Villa?&district=Emmaboda



        //   [HttpGet("type={Type}"), HttpGet("type={Type}&county={County}")]
       /*[HttpGet("{id}")]
        //   [HttpGet]
        public IEnumerable<Homes> get(string? Type = null, string? County = null, int? Price = null)
        {

            IEnumerable<Homes> homes = null;

                homes = (from x in _context.Homes
                         join y in _context.Image
                          on x.HomeId equals y.HomeIds
                         where x.HomeId.Equals(y.HomeIds)
                         select new Homes
                         {
                             HomeId = x.HomeId,
                             Street = x.Street,
                             City = x.City,
                             County = x.County,
                             BrokerId = x.BrokerId,
                             Type = x.Type,
                             LivingArea = x.LivingArea,
                             BiArea = x.BiArea,
                             Room = x.Room,
                             Price = x.Price,
                             LivingSpaceComment = y.ImageAdress

                         });
  
          
            return homes;
        }
  /*
        [HttpGet("&type={Type}")]
        public IEnumerable<Homes> get(string Type)
        {
            IEnumerable<Homes> homes = null;


            homes = from t in _context.Homes
                    where t.Type == Type
                    select t;

            return homes;
        }
        */
        // PUT: api/HomesApi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomes(int id, Homes homes)
        {
            if (id != homes.HomeId)
            {
                return BadRequest();
            }

            _context.Entry(homes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HomesApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Homes>> PostHomes(Homes homes)
        {
            _context.Homes.Add(homes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomes", new { id = homes.HomeId }, homes);
        }

        // DELETE: api/HomesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Homes>> DeleteHomes(int id)
        {
            var homes = await _context.Homes.FindAsync(id);
            if (homes == null)
            {
                return NotFound();
            }

            _context.Homes.Remove(homes);
            await _context.SaveChangesAsync();

            return homes;
        }

        private bool HomesExists(int id)
        {
            return _context.Homes.Any(e => e.HomeId == id);
        }
    }
}
