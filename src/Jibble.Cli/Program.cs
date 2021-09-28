using System;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Threading.Tasks;
using Jibble.Application;
using Jibble.Cli.Commands;
using Jibble.InfraStructure;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Jibble.Cli
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //args = "people update -u russellwhyte -ln fdsa".Split(" ", StringSplitOptions.RemoveEmptyEntries);

            await BuildCommandLine()
                .UseHost(_ => Host.CreateDefaultBuilder(),
                    host =>
                    {
                        host.UseEnvironment("CLI");
                        host.UseSerilog();

                        host.ConfigureServices((hostContext, services) =>
                            {
                                var configuration = hostContext.Configuration;
                                services.AddSerilog();
                                services.AddInfrastructure(configuration);
                                services.AddApplication();
                            })
                            .UseCommandHandler<ListPeopleCommand, ListPeopleCommand.Handler>()
                            .UseCommandHandler<GetPersonDetailsCommand, GetPersonDetailsCommand.Handler>()
                            .UseCommandHandler<CreatePersonCommand, CreatePersonCommand.Handler>()
                            .UseCommandHandler<RemovePersonCommand, RemovePersonCommand.Handler>()
                            .UseCommandHandler<SearchPeopleCommand, SearchPeopleCommand.Handler>()
                            .UseCommandHandler<UpdatePeopleCommand, UpdatePeopleCommand.Handler>()
                            ;
                    })
                .UseDefaults()
                .Build()
                .InvokeAsync(args);
        }

        private static CommandLineBuilder BuildCommandLine()
        {
            var root = new RootCommand();
            root.AddCommand(BuildPeopleCommands());
            root.Handler = CommandHandler.Create(() => root.Invoke("-h"));

            return new CommandLineBuilder(root);


            static Command BuildPeopleCommands()
            {
                var peopleCommands =
                    new Command("people", "Trip persons management https://www.odata.org/odata-services/")
                    {
                        new ListPeopleCommand(),
                        new GetPersonDetailsCommand(),
                        //new CreatePersonCommand(),
                        new RemovePersonCommand(),
                        new SearchPeopleCommand(),
                        new UpdatePeopleCommand()
                    };
                return peopleCommands;
            }
        }
    }
}