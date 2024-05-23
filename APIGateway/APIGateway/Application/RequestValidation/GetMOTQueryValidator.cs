using APIGateway.Application.Queries;
using FluentValidation;

namespace APIGateway.Application.RequestValidation
{
    public class GetMOTQueryValidator : AbstractValidator<GetMOTQuery>
    {
        public GetMOTQueryValidator()
        {
            RuleFor(x => x.Registration).NotEmpty().WithMessage("Registration is required");            
        }
    }
}
