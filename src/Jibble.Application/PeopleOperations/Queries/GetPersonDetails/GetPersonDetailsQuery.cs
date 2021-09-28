using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Queries.GetPersonDetails
{
    public class GetPersonDetailsQuery : IRequest<PersonDetails>
    {
        public string Username { get; set; }
    }
}