using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Commands.AddPerson
{
    public class AddPersonCommand : IRequest<Person>
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }
    }
}