using FluentValidation;
using RestaurantReservation.API;
using RestaurantsReservations.Domain.Validators;

var builder = WebApplication.CreateBuilder(args);

// Apply the database configuration
builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddBusinessServices()
    .AddRepositories()
    .AddMappers()
    .AddValidators();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidators();
builder.Services.AddValidatorsFromAssemblyContaining<CustomerValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();