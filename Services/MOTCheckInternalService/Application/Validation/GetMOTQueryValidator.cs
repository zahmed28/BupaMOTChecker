using FluentValidation;
using MOTCheckInternalService.Application.Queries;

namespace MOTCheckInternalService.Application.Validation
{
    public class GetMOTQueryValidator : AbstractValidator<GetMOTQuery>
    {
        public GetMOTQueryValidator()
        {
            RuleFor(x => x.Registration).NotEmpty().WithMessage("Registration is required.");
        }

    }
}
