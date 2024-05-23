using BupaMOTCheckerUI.Model;
using System.Net.Http;

namespace BupaMOTCheckerUI.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<VehicleResponse> GetVehicleAsync(string registration)
        {
            var request = new VehicleRequest
            {
                Registration = registration
            };
            
            var response = await _httpClient.PostAsJsonAsync("api/MOTCheck", request);
            if (response.IsSuccessStatusCode)
            {
                var vehicleResponse = await response.Content.ReadFromJsonAsync<VehicleResponse>();
                return vehicleResponse;
            }
            else
            {
                // Handle error response
                var errorResponse = new VehicleResponse
                {
                    ErrorMessage = $"Error: {response.ReasonPhrase}"
                };
                return errorResponse;
            }
        }
    }
}
