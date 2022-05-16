namespace FunGuide.Client.Services.SportsmanServices
{
    public interface ISportsmanService
    {
        List<Sportsman> Sportsmen { get; set; }
        List<Sport> Sports { get; set; }
        Task CreateSportsman(Sportsman sportsman);
        Task GetSportsmen();
        Task GetSports();
        Task<Sportsman> GetSingleSportsman(int id);
        Task<Sport> GetSport(int id);
        Task UpdateSportsman(Sportsman sportsman);
        Task DeleteSportsman(int id);
       

    }
}
