using System.Threading;
using System.Threading.Tasks;
using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Commands.AddPerson
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, Person>
    {
        private readonly IUserService _userService;

        public AddPersonCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Person> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                UserName = request.UserName
            };

            await _userService.AddUserAsync(person, cancellationToken);

            return person;
        }
    }
}