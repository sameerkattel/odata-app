using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IRequest<Person>
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}