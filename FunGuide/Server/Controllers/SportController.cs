using Microsoft.AspNetCore.Mvc;

namespace FunGuide.Server.Controllers
{
    [Route("api/sport")]
    [ApiController]
    public class SportContoller : ControllerBase
    {
        private readonly DataContext _context;
        public SportContoller(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<List<Sport>>> CreateSport(Sport sport)
        {
                _context.Sports.Add(sport);
                await _context.SaveChangesAsync();
                return Ok(await _context.Sports.ToListAsync());
            
       

        }
        [HttpGet]
        public async Task<ActionResult<List<Sport>>> GetSports()
        {
            var sports = await _context.Sports.ToListAsync();
            return Ok(sports);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Sport>> GetSport(int id)
        {
            var sport = await _context.Sports.FirstOrDefaultAsync(s => s.Id == id);
            if (sport == null)
            {
                return NotFound("Sorry sport not found");
            }
            return Ok(sport);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Sport>>> UpdateSport(Sport sport, int id)
        {
            var dbSport = await _context.Sports.FirstOrDefaultAsync(h => h.Id == id);
            if (dbSport == null)
            {
                return NotFound("Sorry sportsman not found");
            }
            dbSport.Name = sport.Name;

            await _context.SaveChangesAsync();
            return Ok(await _context.Sports.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSport(int id)
        {
            var dbSport = await _context.Sports.FirstOrDefaultAsync(s => s.Id == id);
            if (dbSport == null)
            {
                return NotFound("Sorry sportsman not found");
            }
            _context.Sports.Remove(dbSport);
            await _context.SaveChangesAsync();
            return Ok(await _context.Sports.ToListAsync());

        }


        [HttpGet("search")]
        public async Task<ActionResult<List<Sportsman>>> SearchSport(string? Name)
        {

            var result = new List<Sport>();
            var emptyList = new List<Sport>();

            if (!string.IsNullOrEmpty(Name))
            {
                result = await _context.Sports.Where(s => s.Name.ToLower().Contains(Name.ToLower())).ToListAsync();
                return Ok(result);

            }
            else
            {
                return Ok(await _context.Sports.ToListAsync());
            }




        }

    }
}
