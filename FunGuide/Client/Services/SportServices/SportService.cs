using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FunGuide.Client.Services.SportServices
{
    public class SportService : ISportService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public SportService(HttpClient http, NavigationManager navigation)
        {
            _http = http;
            _navigationManager = navigation;
       
        }
        public List<Sport> Sports { get; set; }

        public async Task CreateSport(Sport sport)
        {
            var result = await _http.PostAsJsonAsync("/api/sport", sport);
            await SetSport(result);
        }

        public async Task DeleteSport(int id)
        {
            var result = await _http.DeleteAsync($"/api/sport/{id}");
            await SetSport(result);
        }

        public async Task<Sport> GetSport(int id)
        {
            var result = await _http.GetFromJsonAsync<Sport>($"api/sport/{id}");
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Sportsman not found");

            }
        }

        public async Task GetSports()
        {
            var result = await _http.GetFromJsonAsync<List<Sport>>("api/sport");
            if (result != null)
            {
                Sports = result;
            }
            else
            {
                throw new Exception("Sportsmen not found");

            }
        }

        public Task SearchSport(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateSport(Sport sport)
        {
            var result = await _http.PutAsJsonAsync($"/api/sport/{sport.Id}", sport);
            await SetSport(result);
        }


        public async Task SetSport(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Sport>>();
            Sports = response;
        }
    }
}
