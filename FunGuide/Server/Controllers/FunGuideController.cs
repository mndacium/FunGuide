using FunGuide.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FunGuide.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunGuideController : ControllerBase
    {
        public static List<Sportsman> sportsmen = new List<Sportsman>
        {
                new Sportsman
                {
                        Id =1,
                        FirstName="Vlad",
                        LastName ="Tanasiichuk",
                        BirthDate = DateTime.Today,
                        Age = 22,
                        Height = 1.82,
                        Weight = 75.8,
                        Сitizenship=null,
                },
                new Sportsman
                {
                        Id =2,
                        FirstName="Loh",
                        LastName ="Uebok",
                        BirthDate = DateTime.Today,
                        Age = 12,
                        Height = 1.32,
                        Weight = 45.2,
                        Сitizenship="Russian",
                 },
                 new Sportsman
                 {
                        Id =3,
                        FirstName="Andrey",
                        LastName ="Huila",
                        BirthDate = DateTime.Today,
                        Age = 19,
                        Height = 1.65,
                        Weight = 65,
                        Сitizenship="Russian",
                        Sport = sports[0],
                        Team  ="Arsenal"
                 }
        };

        public static List<Sport> sports = new List<Sport>
        {
            new Sport
            {Id=1,Name="Football",RecordHolder = sportsmen[0]},
        };

    }
}
