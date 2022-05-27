namespace FunGuide.Client.Services.SportsmanServices
{
    public interface ISportsmanService
    {
        List<Sportsman> Sportsmen { get; set; }
        List<Sport> Sports { get; set; }
        List<Citizenship> Citizenships { get; set; }

        Task CreateSportsman(Sportsman sportsman);
        Task GetSportsmen();
        Task GetSports();
        Task GetCitizenships();
        Task<Sportsman> GetSingleSportsman(int id);
        Task<Sport> GetSport(int id);
        Task SearchSportsmen(SportsmanSearchModel sportsmanSearchModel);
        Task UpdateSportsman(Sportsman sportsman);
        Task DeleteSportsman(int id);
       

    }
}
