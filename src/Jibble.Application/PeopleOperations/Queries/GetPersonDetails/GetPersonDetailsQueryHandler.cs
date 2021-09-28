using System.Threading;
using System.Threading.Tasks;
using Jibble.Domain.Entities;
using MediatR;

namespace Jibble.Application.PeopleOperations.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryHandler : IRequestHandler<GetPersonDetailsQuery, PersonDetails>
    {
        private readonly IUserService _userService;

        public GetPersonDetailsQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public Task<PersonDetails> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
        {
            return _userService.GetUserByKeyAsync(request.Username, cancellationToken);
        }
    }
}