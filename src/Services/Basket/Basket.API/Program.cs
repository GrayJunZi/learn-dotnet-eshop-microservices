using Basket.API.Data;
using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;

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

var database = builder.Configuration.GetConnectionString("Database");
builder.Services.AddMarten(options =>
    {
        options.Connection(database);
        options.Schema.For<ShoppingCart>().Identity(x => x.UserName);
    })
    .UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddExceptionHandler<CustomerExceptionHandler>();

var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(options => {});

app.Run();