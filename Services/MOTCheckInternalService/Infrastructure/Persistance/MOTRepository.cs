using MOTCheckInternalService.Domain;
using MOTCheckInternalService.Infrastructure.Repositories;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Web;
using System.Text.RegularExpressions;
using System;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace MOTCheckInternalService.Infrastructure.Persistance
{
    public class MOTRepository : IMOTRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<MOTRepository> _logger;
        private readonly IConfiguration _configuration;
        public MOTRepository(IHttpClientFactory httpClientFactory, ILogger<MOTRepository> logger, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory), "HttpClientFactory cannot be null.");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger cannot be null.");
            _configuration = configuration;
        }
        public async Task<VehicleResponse> GetMOTAsync(string registration)
        {
            //Set Api Keys
            string _apiKey = _configuration.GetValue<string>("ApiSettings:ApiKey");
            string _apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");

            // Define the endpoint with the registration parameter
            string endpoint = $"{_apiUrl}?registration={registration}";

            // Create a new HttpClient instance using the factory
            var client = _httpClientFactory.CreateClient();

            // Set up the request headers
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-key", _apiKey); 
           
            try
            {
                // Make the HTTP GET request
                HttpResponseMessage response = await client.GetAsync(endpoint);

                // Read the response content
                string responseBody = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the JSON response to Vehicle object
                    List<Vehicle> vehicles = JsonSerializer.Deserialize<List<Vehicle>>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return new VehicleResponse
                    {
                        Vehicle = vehicles?.FirstOrDefault(),
                        ErrorMessage = null
                    };
                }
                else
                {
                    // Log and return the error message from the service response
                    _logger.LogError($"Service returned error for registration '{registration}': {responseBody}");
                    return new VehicleResponse
                    {
                        Vehicle = null,
                        ErrorMessage = responseBody
                    };
                }               
            }
            catch (HttpRequestException ex)
            {
                // Handle exception if needed
                _logger.LogError($"HTTP request for registration '{registration}' failed: {ex.Message}");

                return new VehicleResponse
                {
                    Vehicle = null,
                    ErrorMessage = ex.Message
                };               
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization errors
                _logger.LogError($"An unexpected error occurred: {ex.Message}");
              
                return new VehicleResponse
                {
                    Vehicle = null,
                    ErrorMessage = ex.Message
                };
            }
            catch (Exception ex)
            {
                // Handle other unexpected errors
                _logger.LogError($"An unexpected error occurred for registration '{registration}': {ex.Message}");
                return new VehicleResponse
                {
                    Vehicle = null,
                    ErrorMessage = ex.Message
                };
            }

        }
    }
}
