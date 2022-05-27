namespace FunGuide.Client.Services.SportServices
{
    public interface ISportService
    {
        List<Sport> Sports { get; set; }
        Task CreateSport(Sport sport);
 
        Task GetSports();
        Task<Sport> GetSport(int id);
        Task SearchSport(string Name);
        Task UpdateSport(Sport sport);
        Task DeleteSport(int id);
    }
}
