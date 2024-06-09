using System.Reflection;
using FluentValidation;
using RestaurantReservation.API;
using RestaurantsReservations.Domain.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();


builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddBusinessServices()
    .AddRepositories()
    .AddMappers()
    .AddValidators();

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    setupAction.IncludeXmlComments(xmlCommentsFullPath);
    // bin\Release\RestaurantReservation.API.xml
});

builder.Services.AddValidators();
builder.Services.AddValidatorsFromAssemblyContaining<CustomerValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();