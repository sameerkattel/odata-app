using FluentValidation;

namespace Jibble.Application.PeopleOperations.Commands.DeletePerson
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty().WithMessage("key/username is required.");
        }
    }
}