using Jibble.Application.PeopleOperations.Queries.SearchPeople;

namespace Jibble.Application
{
    public enum SearchType
    {
        StartsWith,
        EndsWith,
        Contains
    }

    public class PersonSearchFilter
    {
        public SearchType SearchType { get; set; }

        public SearchFieldType SearchFieldType { get; set; }

        public string SearchString { get; set; }
    }
}