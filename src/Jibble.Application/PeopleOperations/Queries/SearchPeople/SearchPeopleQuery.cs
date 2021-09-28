using System.Collections.Generic;
using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Queries.SearchPeople
{
    public class SearchPeopleQuery : PersonSearchFilter, IRequest<List<Person>>
    {
    }


    public enum SearchFieldType
    {
        UserName,
        FirstName,
        LastName
    }
}