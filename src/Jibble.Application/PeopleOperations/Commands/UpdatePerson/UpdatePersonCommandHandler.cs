using System.Threading;
using System.Threading.Tasks;
using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Person>
    {
        private readonly IUserService _userService;

        public UpdatePersonCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };

            var updatedPerson=await _userService.UpdateUserAsync(request.UserName, request.FirstName, request.LastName,cancellationToken);

            return updatedPerson;
        }
    }
}