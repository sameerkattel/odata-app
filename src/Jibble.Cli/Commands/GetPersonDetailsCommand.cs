using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using Jibble.Application.PeopleOperations.Queries.GetPersonDetails;
using MediatR;
using Spectre.Console;

namespace Jibble.Cli.Commands
{
    public class GetPersonDetailsCommand : Command
    {
        public GetPersonDetailsCommand()
            : base("details", "Get person details based on username.")
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
                var query = new GetPersonDetailsQuery
                {
                    Username = Username
                };
                var person = await _mediator.Send(query);

                if (person == null)
                {
                    AnsiConsole.Render(
                        new FigletText($"{Username} does not exist!")
                            .LeftAligned()
                            .Color(Color.Red));
                    return 0;
                }

                var root = new Tree($"[green]{Username}[/]").Style("red");
                ;

                // User Details
                var userDetailsNode = root.AddNode("[yellow]User Details[/]");
                var personTable = new Table().BorderColor(Color.Green)
                    .AddColumn("Username (key)")
                    .AddColumn("Firstname")
                    .AddColumn("Lastname")
                    .AddColumn("Gender");

                personTable.AddRow(person.UserName, person.FirstName, person.LastName, person.Gender);

                userDetailsNode.AddNode(personTable);

                // Trip details
                var tripDetailsNode = root.AddNode("[yellow]Trips Details[/]");
                var tripTable = new Table().BorderColor(Color.Green).Expand()
                    .AddColumn("S.N")
                    .AddColumn("TripId")
                    .AddColumn("ShareId")
                    .AddColumn("Description")
                    .AddColumn("Name")
                    .AddColumn("Budget")
                    .AddColumn("StartsAt")
                    .AddColumn("EndsAt");

                tripDetailsNode.AddNode(tripTable);

                if (person?.Trips?.Count > 0)
                {
                    var count = 1;
                    foreach (var trip in person.Trips)
                    {
                        tripTable.AddRow(count.ToString(), trip.TripId.ToString(), trip.ShareId ?? string.Empty, trip.Description ?? string.Empty,
                            trip.Name ?? string.Empty, trip.Budget.ToString(), trip.StartsAt.ToString("s"), trip.EndsAt.ToString("s"));
                        count++;
                    }
                }
                else
                {
                    tripTable.AddRow("n/a");
                }

                // Friend details
                // User Details
                var friendsDetailsNode = root.AddNode("[yellow]Friends Details[/]");
                var friendsTable = new Table().BorderColor(Color.Green).Expand()
                    .AddColumn("S.N")
                    .AddColumn("Username (key)")
                    .AddColumn("Firstname")
                    .AddColumn("Lastname")
                    .AddColumn("Gender");

                friendsDetailsNode.AddNode(friendsTable);

                if (person?.Friends?.Count > 0)
                {
                    var count = 1;
                    foreach (var friend in person.Friends)
                    {
                        friendsTable.AddRow(count.ToString(), friend.UserName, friend.FirstName, friend.LastName,
                            friend.Gender);
                        count++;
                    }
                }
                else
                {
                    friendsTable.AddRow("n/a");
                }


                // Render the tree
                AnsiConsole.Render(root);

                return 0;
            }
        }
    }
}