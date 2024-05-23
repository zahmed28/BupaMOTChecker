using MOTCheckInternalService.Domain;

namespace MOTCheckInternalService.Infrastructure.Repositories
{
    public interface IMOTRepository
    {
        Task<VehicleResponse> GetMOTAsync(string registration);
    }
}
