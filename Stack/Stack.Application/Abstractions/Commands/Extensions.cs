using Microsoft.Extensions.DependencyInjection;
using Stack.Application.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Abstractions.Commands;

public static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(ICommandHandler<>));
                    })
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
        });

        return services;
    }
}
