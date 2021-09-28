using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Jibble.Application;
using Jibble.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.OData.Client;
using Microsoft.OData.SampleService.Models.TripPin;
using Person = Jibble.Domain.Entities.Person;

namespace Jibble.InfraStructure.Services
{
    public class UserService : IUserService
    {
        private readonly DefaultContainer _container;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(DefaultContainer container, IMapper mapper, ILogger<UserService> logger = null)
        {
            _container = container;
            _logger = logger ?? NullLogger<UserService>.Instance;
            _mapper = mapper;
        }

        /// <summary>
        ///  Get All users
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Person>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            // DataServiceQueryContinuation<T> contains the next link
            DataServiceQueryContinuation<Microsoft.OData.SampleService.Models.TripPin.Person> nextLink = null;

            // Get the first page
            var response =
                await _container.People.ExecuteAsync(cancellationToken) as
                    QueryOperationResponse<Microsoft.OData.SampleService.Models.TripPin.Person>;

            var people = new List<Person>();
            do
            {
                if (nextLink != null)
                    response =
                        await _container.ExecuteAsync(nextLink, cancellationToken) as QueryOperationResponse<
                            Microsoft.OData.SampleService.Models.TripPin.Person>;

                foreach (var person in response)
                {
                    var p = _mapper.Map<Person>(person);

                    people.Add(p);
                }
            }
            // Loop if there is a next link
            while ((nextLink = response.GetContinuation()) != null);

            return people;
        }


        /// <summary>
        /// Search User based on Username/Firstname/Lastname
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<Person>> SearchUsersAsync(PersonSearchFilter filter,
            CancellationToken cancellationToken = default)
        {
            var searchString =
                $"x=>x.{filter.SearchFieldType}.ToLower().{filter.SearchType}(\"{filter.SearchString.ToLower()}\")";
            _logger.LogTrace(searchString);
            var expression = Helper.GetExpression<Microsoft.OData.SampleService.Models.TripPin.Person>(searchString);

            var people = _container.People.Where(expression).ToList();

            var listDest = _mapper.Map<List<Person>>(people);
            return Task.FromResult(listDest);
        }




        /// <summary>
        /// Get User Details by Key
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PersonDetails> GetUserByKeyAsync(string userName,
            CancellationToken cancellationToken = default)
        {
            // TODO paginate inner objects/links
            var person = await _container.People.ByKey(userName).Expand(x => x.Friends).Expand(x => x.Trips)
                .GetValueAsync(cancellationToken);
            if (person == null) return null;

            var p = _mapper.Map<PersonDetails>(person);
            return p;
        }



        /// <summary>
        /// Delete User By Key
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Person> DeleteUserByKeyAsync(string userName,
            CancellationToken cancellationToken = default)
        {
            var person = await _container.People.ByKey(userName).GetValueAsync(cancellationToken);
            if (person == null) return null;

            _container.DeleteObject(person);
            await _container.SaveChangesAsync(cancellationToken);

            var p = _mapper.Map<Person>(person);
            return p;
        }


        /// <summary>
        /// Update User by Key
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Person> UpdateUserAsync(string userName,string firstName,string lastName,
            CancellationToken cancellationToken = default)
        {
            var person = await _container.People.ByKey(userName).GetValueAsync(cancellationToken);
            if (person == null) return null;
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                person.FirstName = firstName;
            }
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                person.LastName = lastName;
            }
            _container.UpdateObject(person);

            await _container.SaveChangesAsync(cancellationToken);

            var p = _mapper.Map<Person>(person);
            return p;
        }


        /// <summary>
        /// Add User.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AddUserAsync(Person input,
            CancellationToken cancellationToken = default)
        {
            var person =
                Microsoft.OData.SampleService.Models.TripPin.Person.CreatePerson(input.UserName, input.FirstName,
                    input.LastName, new long());
            _container.AddToPeople(person);

            await _container.SaveChangesAsync(cancellationToken);
        }
    }
}