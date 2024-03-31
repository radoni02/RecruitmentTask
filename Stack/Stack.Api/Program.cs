

using Stack.Api.Extensions;
using Stack.Application;
using Stack.Application.Extensions;
using Stack.Infrastructure;
using Stack.Infrastructure.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<StackExchangeService>((serviceProvider, httpClient) =>
{
    httpClient.DefaultRequestHeaders.Add("key", "*i5PChBT1XHsIu1OWxqEvg((");
    httpClient.BaseAddress = new Uri("https://api.stackexchange.com");
})
.ConfigurePrimaryHttpMessageHandler(() =>
{   //used to provide safe injection this transient service into singleton
    return new SocketsHttpHandler
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(5)
    };
})
.SetHandlerLifetime(Timeout.InfiniteTimeSpan);


var app = builder.Build();

app.SeedDataProvider();
//app.Services.GetRequiredService<SeedDataIfNeeded>().SeedData() ;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
