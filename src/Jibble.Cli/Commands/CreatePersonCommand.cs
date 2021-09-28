using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Jibble.Application.PeopleOperations.Commands.AddPerson;
using Jibble.Application.PeopleOperations.Commands.UpdatePerson;
using MediatR;
using Spectre.Console;

namespace Jibble.Cli.Commands
{
    public class CreatePersonCommand : Command
    {
        public CreatePersonCommand()
            : base("create", "Create person in the system")
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
                var username = AnsiConsole.Ask<string>("What's your [green]username[/]?");

                var firstname = AnsiConsole.Ask<string>("What's your [green]firstname[/]?");

                var lastname = AnsiConsole.Ask<string>("What's your [green]lastname[/]?");


                var gender = AnsiConsole.Prompt(
                    new TextPrompt<string>("What's your [green]gender[/]?")
                        .DefaultValue("")
                        .AddChoice("Male")
                        .AddChoice("Female")
                        .AllowEmpty());


                var person = await _mediator.Send(new AddPersonCommand()
                {
                    UserName = username,
                    FirstName = firstname,
                    Gender = gender,
                    LastName = lastname
                });

                var table = new Table { Title = new TableTitle($"Create person ({person.UserName})") };
                _ = table.AddColumn("Username (key)");
                _ = table.AddColumn("Firstname");
                _ = table.AddColumn("Lastname");
                _ = table.AddColumn("Gender");

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