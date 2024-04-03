using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Stack.Domain.Model;
using Stack.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.PostgreSql;

namespace Api.IntegrationTests.Abstractions;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithDatabase("runtrackr")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(service =>
        {
            service.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));

            service.AddDbContext<ApplicationDbContext>( options => 
                options.UseNpgsql(_dbContainer.GetConnectionString())
                        .UseSnakeCaseNamingConvention());

            using (var scope = service.BuildServiceProvider().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                dbContext.Database.Migrate();
                dbContext.tags.AddRange(new List<Tag>
            {
                new Tag { Id = Guid.NewGuid(), Name = "Tag1", Count = 5 },
                new Tag { Id = Guid.NewGuid(), Name = "Tag2", Count = 2 },
                new Tag { Id = Guid.NewGuid(), Name = "Tag3", Count = 8}
            });

                dbContext.SaveChanges();
            }
        });
    }
    public Task InitializeAsync()
    {
        return _dbContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        return _dbContainer.StopAsync();
    }
}
