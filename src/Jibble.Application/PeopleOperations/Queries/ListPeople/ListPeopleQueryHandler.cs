using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Queries.ListPeople
{
    public class ListPeopleQueryHandler : IRequestHandler<ListPeopleQuery, List<Person>>
    {
        private readonly IUserService _userService;

        public ListPeopleQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<List<Person>> Handle(ListPeopleQuery request, CancellationToken cancellationToken)
        {
            return _userService.GetAllUsersAsync(cancellationToken);
        }
    }
}