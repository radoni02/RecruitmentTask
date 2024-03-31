using Microsoft.Extensions.DependencyInjection;
using Stack.Application;
using Stack.Application.Extensions;
using Stack.Application.SeedData;
using Stack.Infrastructure.Data.Repository;
using Stack.Infrastructure.Extensions;
using Stack.Infrastructure.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ISeedData, SeedDataToDb>();
        services.AddTransient<IUnPack, UnPack>();
        services.AddTransient<ITagRepository, TagRepository>();
        return services;
    }

}
