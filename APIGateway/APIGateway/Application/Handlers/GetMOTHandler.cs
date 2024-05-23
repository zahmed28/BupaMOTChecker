using APIGateway.Application.Queries;
using APIGateway.Domain.Entities;
using System.Text.Json;
using System.Text;
using MediatR;

namespace APIGateway.Application.Handlers
{
    public class GetMOTHandler : IRequestHandler<GetMOTQuery, VehicleResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<GetMOTHandler> _logger;
        public GetMOTHandler(IConfiguration configuration, IHttpClientFactory clientFactory, ILogger<GetMOTHandler> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }
        public async Task<VehicleResponse> Handle(GetMOTQuery request, CancellationToken cancellationToken)
        {
            var apiUrl = _configuration.GetValue<string>("MOTCheckServiceUrl") ?? throw new InvalidOperationException("API URL is not configured.");
            var requestUrl = $"{apiUrl}";

            try
            {
                var vehicleResponse = await PostAsync<VehicleResponse>(requestUrl, request, cancellationToken);
               
                return vehicleResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while calling the MOTCheck.");
                throw; // Or handle it as per your error handling strategy
            }
        }

        private async Task<T> PostAsync<T>(string requestUrl, object contentValue, CancellationToken cancellationToken) where T : new()
        {
            var client = _clientFactory.CreateClient();
            var json = JsonSerializer.Serialize(contentValue);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(requestUrl, content, cancellationToken);
            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<T>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, cancellationToken);
            return result ?? new T();
        }
    }
}
