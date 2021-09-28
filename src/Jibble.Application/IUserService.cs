using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Jibble.Domain.Entities;

namespace Jibble.Application
{
    public interface IUserService
    {
        Task<List<Person>> GetAllUsersAsync(CancellationToken cancellationToken = default);

        Task<List<Person>> SearchUsersAsync(PersonSearchFilter filter, CancellationToken cancellationToken = default);

        Task<PersonDetails> GetUserByKeyAsync(string userName, CancellationToken cancellationToken = default);

        Task<Person> DeleteUserByKeyAsync(string userName,
            CancellationToken cancellationToken = default);

        Task AddUserAsync(Person input, CancellationToken cancellationToken = default);

        Task<Person> UpdateUserAsync(string userName, string firstName, string lastName,
            CancellationToken cancellationToken = default);
    }
}