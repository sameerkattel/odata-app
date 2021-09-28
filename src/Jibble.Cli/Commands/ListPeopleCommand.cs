using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;
using Jibble.Application.PeopleOperations.Queries.ListPeople;
using MediatR;
using Spectre.Console;

namespace Jibble.Cli.Commands
{
    public class ListPeopleCommand : Command
    {
        public ListPeopleCommand()
            : base("list", "Lists all persons lists in the system.")
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
                var people = await _mediator.Send(new ListPeopleQuery());
                var table = new Table { Title = new TableTitle($"People List({people.Count})") };
                _ = table.AddColumn("Username (key)");
                _ = table.AddColumn("Firstname");
                _ = table.AddColumn("Lastname");
                _ = table.AddColumn("Gender");

                foreach (var person in people)
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