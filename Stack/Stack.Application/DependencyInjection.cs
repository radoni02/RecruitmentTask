using Microsoft.Extensions.DependencyInjection;
using Stack.Application.Abstractions.Commands;
using Stack.Application.Abstractions.Queries;
using Stack.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddQueries();
        services.AddCommands();
        services.AddScoped<SeedDataIfNeeded>();
        return services;
    }

}
