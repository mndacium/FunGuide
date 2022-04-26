using FunGuide.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace FunGuide.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunGuideController : ControllerBase
    {
        public static List<Sport> sports = new List<Sport>
        {
            new Sport
            {Id=1,Name="Football"},
            new Sport
            { Id = 2, Name = "MMA"}
        };

        public static List<Sportsman> sportsmen = new List<Sportsman> {
            new Sportsman
            {
             Id = 1,
             FirstName = "Vlad",
             LastName = "Tanasiichuk",
             BirthDate = DateTime.Today,
             Age = 22,
             Height = 1.82,
             Weight = 75.8,
             Сitizenship = "Ukrainian",
             Sport = sports[1]
            },
            new Sportsman
            {
             Id = 2,
             FirstName = "Andrey",
             LastName = "Huila",
             BirthDate = DateTime.Today,
             Age = 21,
             Height = 1.8,
             Weight = 75.3,
             Сitizenship = "Ukrainian",
             Sport = sports[0]
            },

        };
        


        [HttpGet]
        public async Task<ActionResult<List<Sportsman>>> GetSportsmen()
        {
            return Ok(sportsmen);
        }
        [HttpGet("{id}")]
        
        public async Task<ActionResult<Sportsman>> GetSingleSportsman(int id)
        {
            var sportsman = sportsmen.FirstOrDefault(s => s.Id == id);
            if (sportsman == null)
            {
                return NotFound("Sorry sportsman not found");
            }
          return Ok(sportsman);
        }



    }
}
