using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Jibble.Application.PeopleOperations.Commands.UpdatePerson;
using MediatR;
using Spectre.Console;

namespace Jibble.Cli.Commands
{
    public class UpdatePeopleCommand : Command
    {
        public UpdatePeopleCommand()
            : base("update", "Update person.")
        {
            Option userName = new Option<string>(
                aliases: new string[] { "--username", "-u" }
                , description: "The username/key of the person."
            )
            {
                IsRequired = true
            };

            Option firstName = new Option<string>(
                aliases: new string[] { "--firstname", "-fn" }
                , description: "new firstName of the person."
            )
            {
       Arity = ArgumentArity.ExactlyOne
            };


            Option lastName = new Option<string>(
                aliases: new string[] { "--lastname", "-ln" }
                , description: "new lastname of the person."
            )
            {
                Arity = ArgumentArity.ExactlyOne
            };

            AddOption(userName);
            AddOption(firstName);
            AddOption(lastName);
        }

        public IConsole Console { get; set; }

        public new class Handler : ICommandHandler
        {
            private readonly IMediator _mediator;

            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Handler(IMediator mediator)
            {
                _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            }

            public async Task<int> InvokeAsync(InvocationContext context)
            {
                var updatedPerson = await _mediator.Send(new UpdatePersonCommand()
                {
                    UserName = UserName,
                    FirstName = FirstName,
                    LastName = LastName
                });

                if (updatedPerson == null)
                {
                    AnsiConsole.Render(
                        new FigletText($"{UserName} does not exist!")
                            .LeftAligned()
                            .Color(Color.Red));
                    return 0;
                }
                var table = new Table { Title = new TableTitle($"Updated {UserName}") };
                _ = table.AddColumn("Username (key)");
                _ = table.AddColumn("Firstname");
                _ = table.AddColumn("Lastname");
                _ = table.AddColumn("Gender");

            
                table.AddRow(updatedPerson.UserName ?? string.Empty, updatedPerson.FirstName ?? string.Empty, updatedPerson.LastName ?? string.Empty, updatedPerson.Gender??string.Empty );


                var grid = new Grid().Alignment(Justify.Center);
                grid.AddColumn(new GridColumn());
                grid.AddRow(table);


                AnsiConsole.Render(new Panel(grid));
                return 0;
            }
        }
    }
}