using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Net.Http.Json;

namespace FunGuide.Client.Services.SportsmanServices
{

    public class SportsmanService : ISportsmanService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public SportsmanService(HttpClient http,NavigationManager navigation) { 
            _http = http;
            _navigationManager = navigation;
        }
        public List<Sportsman> Sportsmen { get; set; } = new List<Sportsman>();
        public List<Sport> Sports { get; set; } = new List<Sport>();
        public async Task<Sportsman> GetSingleSportsman(int id)
        {
            var result = await _http.GetFromJsonAsync<Sportsman>($"api/funguide/{id}");
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Sportsman not found");

            }
        }

        public async Task<Sport> GetSport(int id)
        {
            var result = await _http.GetFromJsonAsync<Sport>($"api/funguide/sports/{id}");
            if (result != null)
            {
                return result;  
            }
            else
            {
                throw new Exception("Sport not found");

            }
        }

        public async Task GetSportsmen()
        {
            var result = await _http.GetFromJsonAsync<List<Sportsman>>("api/funguide");
            if (result != null)
            {
                Sportsmen = result;
            }
            else
            {
                throw new Exception("Sportsmen not found");

            }

        }
        public async Task GetSports()
        {
            var result = await _http.GetFromJsonAsync<List<Sport>>("api/funguide/sports");
            if (result != null)
            {
                Sports = result;
            }
            else
            {
                throw new Exception("Sports not found");

            }
        }

        public async Task CreateSportsman(Sportsman sportsman)
        {
            var result = await _http.PostAsJsonAsync("/api/funguide", sportsman);
            await SetSportsmen(result);
            }

        public async Task UpdateSportsman(Sportsman sportsman)
        {
            var result = await _http.PutAsJsonAsync($"/api/funguide/{sportsman.Id}",sportsman);
            await SetSportsmen(result);
        }

        public async Task DeleteSportsman(int id)
        {
            var result = await _http.DeleteAsync($"/api/funguide/{id}");
            await SetSportsmen(result);
        }
        public async Task SetSportsmen(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Sportsman>>();
            Sportsmen = response;
            _navigationManager.NavigateTo("/");
        }

        public async Task SearchSportsmen(string? searchText,int? sportId)
        {
            
            var result = await _http.GetFromJsonAsync<List<Sportsman>>($"/api/funguide/search?searchText={searchText}&sportId={sportId}");
            

            if(result!=null)
            {
                Sportsmen = result;
            }
            else
            {
                throw new Exception("Search not found");
            }


        }
    }


}
 

