using Stack.Application.Extensions;
using Stack.Infrastructure.Data;

namespace Stack.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void SeedDataProvider(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        scope.ServiceProvider.GetRequiredService<SeedDataIfNeeded>().SeedData();
    }


}
