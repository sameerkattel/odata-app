using FluentValidation;

namespace Jibble.Application.PeopleOperations.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryValidator : AbstractValidator<GetPersonDetailsQuery>
    {
        public GetPersonDetailsQueryValidator()
        {
            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty().WithMessage("key/username is required.");
        }
    }
}