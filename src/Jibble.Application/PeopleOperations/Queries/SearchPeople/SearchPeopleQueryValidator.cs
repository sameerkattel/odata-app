using FluentValidation;

namespace Jibble.Application.PeopleOperations.Queries.SearchPeople
{
    public class SearchPeopleQueryValidator : AbstractValidator<SearchPeopleQuery>
    {
        public SearchPeopleQueryValidator()
        {
            RuleFor(x => x.SearchString).NotEmpty();
        }
    }
}