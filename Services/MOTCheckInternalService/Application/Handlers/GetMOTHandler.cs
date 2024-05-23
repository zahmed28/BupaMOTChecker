using MediatR;
using MOTCheckInternalService.Application.Queries;
using MOTCheckInternalService.Domain;
using MOTCheckInternalService.Infrastructure.Repositories;

namespace MOTCheckInternalService.Application.Handlers
{
    public class GetMOTHandler : IRequestHandler<GetMOTQuery, VehicleResponse>
    {
        private readonly IMOTRepository _mOTRepository;
        public GetMOTHandler(IMOTRepository mOTRepository)
        {
            _mOTRepository = mOTRepository;
        }

        public async Task<VehicleResponse> Handle(GetMOTQuery request, CancellationToken cancellationToken)
        {           
           var result = await _mOTRepository.GetMOTAsync(request.Registration);
            return result;
        }       
    }
}
