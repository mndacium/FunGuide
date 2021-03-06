using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Net.Http.Json;

namespace FunGuide.Client.Services.SportsmanServices
{

    public class SportsmanService : ISportsmanService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        private readonly ISportService _sportService;
        public SportsmanService(HttpClient http, NavigationManager navigation,ISportService sportService)
        {
            _http = http;
            _navigationManager = navigation;
            _sportService = sportService;
        }
        public List<Sportsman> Sportsmen { get; set; } = new List<Sportsman>();
        
        public List<Citizenship> Citizenships { get; set; } = new List<Citizenship>();

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


        public async Task CreateSportsman(Sportsman sportsman)
        {
            var result = await _http.PostAsJsonAsync("/api/funguide", sportsman);
            await SetSportsmen(result);
        }

        public async Task UpdateSportsman(Sportsman sportsman)
        {
            var result = await _http.PutAsJsonAsync($"/api/funguide/{sportsman.Id}", sportsman);
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

        public async Task SearchSportsmen(SportsmanSearchModel sportsmanSearchModel)
        {

            var result = await _http.GetFromJsonAsync<List<Sportsman>>($"/api/funguide/search?" +
                $"Name={sportsmanSearchModel.Name}" +
                $"&Age={sportsmanSearchModel.Age}" +
                $"&HeightFrom={sportsmanSearchModel.HeightFrom}" +
                $"&HeightTo={sportsmanSearchModel.HeightTo}" +
                $"&WeightFrom={sportsmanSearchModel.WeightFrom}" +
                $"&WeightTo={sportsmanSearchModel.WeightTo}" +
                $"&citizenshipId={sportsmanSearchModel.CitizenshipId}"+
                $"&sportId={sportsmanSearchModel.SportId}" +
                $"&Team={sportsmanSearchModel.Team}"+
                $"&BirthYear={sportsmanSearchModel.BirthYear}"


                );


            if (result != null)
            {
                Sportsmen = result;
            }
            else
            {
                throw new Exception("Search not found");
            }


        }

        public async Task GetCitizenships()
        {
            var result = await _http.GetFromJsonAsync<List<Citizenship>>("api/funguide/citizenships");
            if (result != null)
            {
                Citizenships = result;
            }
            else
            {
                throw new Exception("Sports not found");

            }
        }
    }


}
 

