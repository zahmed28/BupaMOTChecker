using MediatR;
using MOTCheckInternalService.Domain;

namespace MOTCheckInternalService.Application.Queries
{
    public class GetMOTQuery : IRequest<VehicleResponse>
    {
        public string Registration { get; set; }
    }
}
