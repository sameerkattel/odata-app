using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Jibble.Application.PeopleOperations.Commands.DeletePerson;
using MediatR;
using Spectre.Console;

namespace Jibble.Cli.Commands
{
    public class RemovePersonCommand : Command
    {
        public RemovePersonCommand()
            : base("delete", "Delete person using username/key.")
        {
            AddArgument(new Argument<string>("username", "username/key of the person"));
        }

        public IConsole Console { get; set; }

        public new class Handler : ICommandHandler
        {
            private readonly IMediator _mediator;

            public Handler(IMediator mediator)
            {
                _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            }

            public string Username { get; set; }

            public async Task<int> InvokeAsync(InvocationContext context)
            {
                var deleteCommand = new DeletePersonCommand
                {
                    UserName = Username
                };

                var deletedPerson = await _mediator.Send(deleteCommand);

                if (deletedPerson == null)
                    AnsiConsole.Render(
                        new FigletText($"{Username} does not exist!")
                            .LeftAligned()
                            .Color(Color.Red));
                else
                    AnsiConsole.Render(new Text($"{Username} has been deleted."));

                return 0;
            }
        }
    }
}