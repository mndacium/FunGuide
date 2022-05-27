namespace FunGuide.Client.Services.SportsmanServices
{
    public interface ISportsmanService
    {
        List<Sportsman> Sportsmen { get; set; }
        List<Citizenship> Citizenships { get; set; }

        Task CreateSportsman(Sportsman sportsman);
        Task GetSportsmen();
        Task GetCitizenships();
        Task<Sportsman> GetSingleSportsman(int id);
        Task SearchSportsmen(SportsmanSearchModel sportsmanSearchModel);
        Task UpdateSportsman(Sportsman sportsman);
        Task DeleteSportsman(int id);
       

    }
}
