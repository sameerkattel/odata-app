using System.Threading;
using System.Threading.Tasks;
using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Person>
    {
        private readonly IUserService _userService;

        public DeletePersonCommandHandler(IUserService userService)
        {
            _userService = userService;
        }


        public Task<Person> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var deletedUser = _userService.DeleteUserByKeyAsync(request.UserName, cancellationToken);

            return deletedUser;
        }
    }
}