namespace FunGuide.Client.Services.SportsmanServices
{
    public interface ISportsmanService
    {
        List<Sportsman> Sportsmen { get; set; }
        List<Sport> Sports { get; set; }
        Task GetSport();
        Task GetSportsmen();
        Task<Sportsman> GetSingleSportsman(int id);
       

    }
}
