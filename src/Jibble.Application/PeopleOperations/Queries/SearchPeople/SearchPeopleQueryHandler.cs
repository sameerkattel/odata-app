using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Queries.SearchPeople
{
    public class SearchPeopleQueryHandler : IRequestHandler<SearchPeopleQuery, List<Person>>
    {
        private readonly IUserService _userService;

        public SearchPeopleQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<List<Person>> Handle(SearchPeopleQuery request, CancellationToken cancellationToken)
        {
            var results = _userService.SearchUsersAsync(request, cancellationToken);

            return results;
        }
    }
}