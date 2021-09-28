using System.Collections.Generic;
using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Queries.ListPeople
{
    public class ListPeopleQuery : IRequest<List<Person>>
    {
    }
}