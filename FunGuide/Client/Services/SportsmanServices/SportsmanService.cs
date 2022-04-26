using System.Net.Http.Json;

namespace FunGuide.Client.Services.SportsmanServices
{

    public class SportsmanService : ISportsmanService
    {
        private readonly HttpClient _http;
        public SportsmanService(HttpClient http) { _http = http; }
        public List<Sportsman> Sportsmen { get; set; } = new List<Sportsman>();
        public List<Sport> Sports { get; set; } = new List<Sport>();
        public async Task<Sportsman> GetSingleSportsman(int id)
        {
            var result = await _http.GetFromJsonAsync<Sportsman>($"api/funguide/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Sportsman not found");
        }

        public async Task GetSport()
        {
            var result = await _http.GetFromJsonAsync<List<Sport>>("api/funguide/sports");
            if (result != null)
            {
                Sports = result;
            }
        }

        public async Task GetSportsmen()
        {
            var result = await _http.GetFromJsonAsync<List<Sportsman>>("api/funguide");
            if (result != null)
            {
                Sportsmen = result;
            }

        }
        public async Task GetSports()
        {
            var result = await _http.GetFromJsonAsync<List<Sport>>("api/sports");
            if (result != null)
            {
                Sports = result;
            }
            throw new Exception("Sport not found");
        }
    }
}
