using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stack.Application;
using Stack.Application.Extensions;
using Stack.Application.SeedData;
using Stack.Application.Tags.CountPercentage;
using Stack.Infrastructure.CountPercentage;
using Stack.Infrastructure.Data;
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
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });
        services.AddScoped<ISeedData, SeedDataToDb>();
        services.AddScoped<IUnPack, UnPack>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IPercentageCounter, PercentageCounter>();

        return services;
    }

}
