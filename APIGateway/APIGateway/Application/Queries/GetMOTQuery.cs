using APIGateway.Domain.Entities;
using MediatR;

namespace APIGateway.Application.Queries
{
    public class GetMOTQuery : IRequest<VehicleResponse>
    {
        public string Registration { get; set; }
    }
}
