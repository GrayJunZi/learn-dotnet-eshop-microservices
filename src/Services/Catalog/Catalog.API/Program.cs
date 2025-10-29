using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;
using Catalog.API.Data;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCarter();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);

var databaseConnectionString = builder.Configuration.GetConnectionString("Database");
if (string.IsNullOrEmpty(databaseConnectionString))
    throw new Exception();

builder.Services.AddMarten(options => options.Connection(databaseConnectionString))
    .UseLightweightSessions();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

builder.Services.AddExceptionHandler<CustomerExceptionHandler>();

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString);

var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();