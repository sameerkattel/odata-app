using FluentValidation;

namespace Jibble.Application.PeopleOperations.Commands.UpdatePerson
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty().WithMessage("key/username is required.");

            RuleFor(x => x.FirstName)
                .NotEmpty().When(x=>string.IsNullOrWhiteSpace(x.LastName)).WithMessage("FirstName and Lastname both cannot be empty/null");

        }
    }
}