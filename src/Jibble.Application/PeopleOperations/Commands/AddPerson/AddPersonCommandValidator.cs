using FluentValidation;

namespace Jibble.Application.PeopleOperations.Commands.AddPerson
{
    public class AddPersonCommandValidator : AbstractValidator<AddPersonCommand>
    {
        public AddPersonCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty().WithMessage("key/username is required.");

            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty().WithMessage("key/username is required.");

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty().WithMessage("key/username is required.");
        }
    }
}