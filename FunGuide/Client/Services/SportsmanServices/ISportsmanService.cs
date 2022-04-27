namespace FunGuide.Client.Services.SportsmanServices
{
    public interface ISportsmanService
    {
        List<Sportsman> Sportsmen { get; set; }
        List<Sport> Sports { get; set; }
        Task CreateSportsman(Sportsman sportsman);
        Task GetSport();
        Task GetSportsmen();
        Task<Sportsman> GetSingleSportsman(int id);
        Task UpdateSportsman(Sportsman sportsman);
        Task DeleteSportsman(int id);
       

    }
}
