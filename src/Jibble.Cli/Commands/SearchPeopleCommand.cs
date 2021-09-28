using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Jibble.Application;
using Jibble.Application.PeopleOperations.Queries.SearchPeople;
using MediatR;
using Spectre.Console;

namespace Jibble.Cli.Commands
{
    public class SearchPeopleCommand : Command
    {
        public SearchPeopleCommand()
            : base("search", "Search people in the system")
        {
        }

        public IConsole Console { get; set; }

        public new class Handler : ICommandHandler
        {
            private readonly IMediator _mediator;

            public Handler(IMediator mediator)
            {
                _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            }

            public async Task<int> InvokeAsync(InvocationContext context)
            {
                var searchFieldType = AnsiConsole.Prompt(new SelectionPrompt<SearchFieldType>()
                    .AddChoices(SearchFieldType.UserName, SearchFieldType.FirstName, SearchFieldType.LastName)
                    .Title("Select [green]Search on[/]?"));
                ;

                var searchType = AnsiConsole.Prompt(new SelectionPrompt<SearchType>()
                    .AddChoices(SearchType.StartsWith, SearchType.EndsWith, SearchType.Contains)
                    .Title("Select [green]SearchType[/]?"));
                ;

                var searchString = AnsiConsole.Prompt(
                    new TextPrompt<string>("[green]Search String[/]?"));

                var searchPeopleQuery = new SearchPeopleQuery
                {
                    SearchType = searchType,
                    SearchFieldType = searchFieldType,
                    SearchString = searchString
                };


                var results = await _mediator.Send(searchPeopleQuery);

                var table = new Table { Title = new TableTitle($"People List({results.Count})") };
                _ = table.AddColumn("Username (key)");
                _ = table.AddColumn("Firstname");
                _ = table.AddColumn("Lastname");
                _ = table.AddColumn("Gender");

                foreach (var person in results)
                    table.AddRow(person.UserName ?? string.Empty, person.FirstName ?? string.Empty, person.LastName ?? string.Empty, person.Gender ?? string.Empty);


                var grid = new Grid().Alignment(Justify.Center);
                grid.AddColumn(new GridColumn());
                grid.AddRow(table);


                AnsiConsole.Render(new Panel(grid));

                return 0;
            }
        }
    }
}