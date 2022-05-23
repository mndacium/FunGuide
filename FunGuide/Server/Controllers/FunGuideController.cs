using FunGuide.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FunGuide.Client.Services.SportsmanServices;
using System.Diagnostics;
using System.Reflection;

namespace FunGuide.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunGuideController : ControllerBase
    {
        private readonly DataContext _context;
        public FunGuideController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Sportsman>>> CreateSportsman(Sportsman sportsman)
        {

            sportsman.Sport = null;
            _context.Add(sportsman);
            await _context.SaveChangesAsync();
            return Ok(await GetDbSportsmen());

        }

        [HttpGet]
        public async Task<ActionResult<List<Sportsman>>> GetSportsmen()
        {
            var sportsmen = await GetDbSportsmen();
            return Ok(sportsmen);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sportsman>> GetSingleSportsman(int id)
        {
            var sportsman = await _context.Sportsmen.Include(s => s.Sport).FirstOrDefaultAsync(h => h.Id == id);
            if (sportsman == null)
            {
                return NotFound("Sorry sportsman not found");
            }
            return Ok(sportsman);
        }

        [HttpGet("sports")]
        public async Task<ActionResult<List<Sport>>> GetSports()
        {
            var sports = await _context.Sports.ToListAsync();
            return Ok(sports);
        }
        [HttpGet("sports/{id}")]
        public async Task<ActionResult<Sport>> GetSport(int id)
        {
            var sport = await _context.Sports.FirstOrDefaultAsync(s => s.Id == id);
            if (sport == null)
            {
                return NotFound("Sorry sport not found");
            }
            return Ok(sport);
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<Sportsman>>> SearchSportsmen(string? searchText, int? sportId)
        {

            var result = new List<Sportsman>();
            var searchQueryModel = new SportsmanSearchModel
            {
                Name = searchText,
                SportId = sportId
            };

            if (!string.IsNullOrEmpty(searchText) && sportId != 0)
            {
                result = await _context.Sportsmen.Include(s => s.Sport).Where(s => (s.FirstName + s.LastName).ToLower().Contains(searchQueryModel.Name.ToLower()) && s.SportId == searchQueryModel.SportId).ToListAsync();
            }
            else if (string.IsNullOrEmpty(searchText) && sportId == 0)
            {
                result = await GetDbSportsmen();
                result = await _context.Sportsmen.Include(s => s.Sport).Where(s => s.SportId == searchQueryModel.SportId).ToListAsync();
            }
            else
            {
                if (sportId != 0)
                {
                    result.AddRange(await _context.Sportsmen.Include(s => s.Sport).Where(s => s.SportId == searchQueryModel.SportId).ToListAsync());
                }
                if (!string.IsNullOrEmpty(searchText))
                {
                    result.AddRange(await _context.Sportsmen.Include(s => s.Sport).Where(s => (s.FirstName + s.LastName).ToLower().Contains(searchQueryModel.Name.ToLower())).ToListAsync());
                }
                if (result.Any())
                {
                    var maxRepetitions = result.GroupBy(s => s)
               .OrderByDescending(s => s.Count()).First().Count();
                    var maxRepeated = result.GroupBy(s => s).OrderByDescending(s => s.Count()).Where(s => s.Count() == maxRepetitions).Select(s => s.Key).ToList();
                    if (maxRepeated.Any())
                    {
                        return Ok(maxRepeated);
                    }
                }
                
                return Ok(result);
                result = await _context.Sportsmen.Include(s => s.Sport).Where(s => (s.FirstName + s.LastName).ToLower().Contains(searchQueryModel.Name.ToLower())).ToListAsync();

            }

            return Ok(result);
           







        }
        
       
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Sportsman>>> UpdateSportsman(Sportsman sportsman, int id)
        {

            var dbSportsman = await _context.Sportsmen.Include(s => s.Sport).FirstOrDefaultAsync(h => h.Id == id);
            if (dbSportsman == null)
            {
                return NotFound("Sorry sportsman not found");
            }
            dbSportsman.FirstName = sportsman.FirstName;
            dbSportsman.LastName = sportsman.LastName;
            dbSportsman.Age = sportsman.Age;
            dbSportsman.BirthDate = sportsman.BirthDate;
            dbSportsman.Citizenship = sportsman.Citizenship;
            dbSportsman.Height = sportsman.Height;
            dbSportsman.Weight = sportsman.Weight;
            dbSportsman.SportId = sportsman.SportId;
            dbSportsman.Team = sportsman.Team;
            await _context.SaveChangesAsync();
            return Ok(await GetDbSportsmen());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSportsman(int id)
        {
            var dbSportsman = await _context.Sportsmen.Include(s => s.Sport).FirstOrDefaultAsync(s => s.Id == id);
            if (dbSportsman == null)
            {
                return NotFound("Sorry sportsman not found");
            }
            _context.Sportsmen.Remove(dbSportsman);
            await _context.SaveChangesAsync();
            return Ok(await GetDbSportsmen());

        }


        public async Task<List<Sportsman>> GetDbSportsmen()
        {
            return await _context.Sportsmen.Include(s => s.Sport).ToListAsync();
        }
    }
}
