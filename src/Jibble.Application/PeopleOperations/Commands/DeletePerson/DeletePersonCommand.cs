using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest<Person>
    {
        public string UserName { get; set; }
    }
}