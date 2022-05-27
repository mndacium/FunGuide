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
            var sportsman = await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship).FirstOrDefaultAsync(h => h.Id == id);
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
        [HttpGet("citizenships")]
        public async Task<ActionResult<List<Citizenship>>> GetCitizenships()
        {
            var citizenships = await _context.Citizenships.ToListAsync();
            return Ok(citizenships);
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
        public async Task<ActionResult<List<Sportsman>>> SearchSportsmen(string? Name, int? Age, double? HeightFrom, double? HeightTo, double? WeightFrom, double? WeightTo, int? citizenshipId, int? sportId, string? Team)
        {

            var result = new List<Sportsman>();
            var emptyList = new List<Sportsman>();
            var searchQueryModel = new SportsmanSearchModel
            {
                Name = Name,
                Age = Age,
                HeightFrom=HeightFrom,
                HeightTo=HeightTo,
                WeightFrom=WeightFrom,
                WeightTo=WeightTo,
                CitizenshipId = citizenshipId,
                SportId = sportId,
                Team = Team
            };

            if (!string.IsNullOrEmpty(Name) && Age != null && HeightFrom != null && HeightTo != null && WeightFrom != null && WeightTo != null && citizenshipId != 0 && sportId != 0 && !string.IsNullOrEmpty(Team))
            {
                result = await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship)
                    .Where(s => 
                    (s.FirstName + s.LastName).ToLower().Contains(searchQueryModel.Name.ToLower())
                    && s.Age == searchQueryModel.Age
                    && s.Height>=searchQueryModel.HeightFrom
                    && s.Height <= searchQueryModel.HeightTo
                    && s.Weight >= searchQueryModel.WeightFrom
                    && s.Weight <= searchQueryModel.WeightTo
                    && s.CitizenshipId == searchQueryModel.CitizenshipId
                    && s.SportId == searchQueryModel.SportId
                    && s.Team.ToLower().Contains(Team.ToLower()) 
                    )


                    .ToListAsync();
                return Ok(result);
            }
            else if (string.IsNullOrEmpty(Name) && Age == null && HeightFrom == null && HeightTo == null && WeightFrom == null && WeightTo == null && citizenshipId == 0 && sportId == 0 && string.IsNullOrEmpty(Team))
            {
                result = await GetDbSportsmen();
                return Ok(result);
            }
            else
            {
                int filtersCount = 0;
                if (sportId != 0)
                {
                    result.AddRange(await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship)
                        .Where(s => s.SportId == searchQueryModel.SportId).ToListAsync());
                    filtersCount++;
                }
                if (!string.IsNullOrEmpty(Name))
                {
                    result.AddRange(await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship)
                        .Where(s => (s.FirstName + s.LastName).ToLower().Contains(searchQueryModel.Name.ToLower())).ToListAsync());
                    filtersCount++;

                }
                if (Age != null)
                {
                    result.AddRange(await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship)
                        .Where(s => s.Age == searchQueryModel.Age).ToListAsync());
                    filtersCount++;
                }
                if (HeightFrom != null)
                {
                    result.AddRange(await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship)
                        .Where(s => s.Height >= searchQueryModel.HeightFrom).ToListAsync());
                    filtersCount++;
                }
                if (HeightTo != null)
                {
                    result.AddRange(await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship)
                        .Where(s => s.Height <= searchQueryModel.HeightTo).ToListAsync());
                    filtersCount++;
                }
                if (WeightFrom != null)
                {
                    result.AddRange(await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship)
                        .Where(s => s.Weight >= searchQueryModel.WeightFrom).ToListAsync());
                    filtersCount++;
                }
                if (WeightTo != null)
                {
                    result.AddRange(await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship)
                        .Where(s => s.Weight <= searchQueryModel.WeightTo).ToListAsync());
                    filtersCount++;
                }
                if (citizenshipId != 0)
                {
                    result.AddRange(await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship)
                        .Where(s => s.CitizenshipId == searchQueryModel.CitizenshipId).ToListAsync());
                    filtersCount++;
                }
                if (!string.IsNullOrEmpty(Team))
                {
                    result.AddRange(await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship)
                        .Where(s => s.Team.ToLower().Contains(searchQueryModel.Team.ToLower())).ToListAsync());
                    filtersCount++;

                }
                if (result.Any())
                {
                    var maxRepetitions = result.GroupBy(s => s)
                    .OrderByDescending(s => s.Count()).First().Count();
                    var maxRepeated = result.GroupBy(s => s).OrderByDescending(s => s.Count())
                        .Where(s => s.Count() == maxRepetitions).Select(s => s.Key).ToList();
                    if (maxRepeated.Any() && maxRepetitions == filtersCount)
                    {
                        return Ok(maxRepeated);
                    }
                    else
                    {
                        return Ok(emptyList);
                    }
                }
                else
                {
                    return Ok(emptyList);
                }

                return Ok(result);

            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Sportsman>>> UpdateSportsman(Sportsman sportsman, int id)
        {

            var dbSportsman = await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship).FirstOrDefaultAsync(h => h.Id == id);
            if (dbSportsman == null)
            {
                return NotFound("Sorry sportsman not found");
            }
            dbSportsman.FirstName = sportsman.FirstName;
            dbSportsman.LastName = sportsman.LastName;
            dbSportsman.Age = sportsman.Age;
            dbSportsman.BirthDate = sportsman.BirthDate;
            dbSportsman.CitizenshipId = sportsman.CitizenshipId;
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
            var dbSportsman = await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship).FirstOrDefaultAsync(s => s.Id == id);
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
            return await _context.Sportsmen.Include(s => s.Sport).Include(s => s.Citizenship).ToListAsync();
        }
    }
}
