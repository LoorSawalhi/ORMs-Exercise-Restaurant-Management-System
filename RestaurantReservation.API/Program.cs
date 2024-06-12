using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestaurantReservation.API;
using RestaurantsReservations.Domain.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddVersionedApiExplorer(setupAction =>
    {
        setupAction.SubstituteApiVersionInUrl = true;
    }
);

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddBusinessServices()
    .AddRepositories()
    .AddMappers()
    .AddValidators();

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Authentication:Issuer"],
                ValidAudience = builder.Configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Convert.FromBase64String(builder.Configuration["Authentication:SecretForKey"]))
            };
        }
    );

builder.Services.AddApiVersioning(setupAction =>
    {
        setupAction.ReportApiVersions = true;
        setupAction.AssumeDefaultVersionWhenUnspecified = true;
        setupAction.DefaultApiVersion = new ApiVersion(1, 0);
    }
).AddMvc();

var apiVersionDescriptionProvider = builder.Services.BuildServiceProvider()
    .GetRequiredService<IApiVersionDescriptionProvider>();

builder.Services.AddSwaggerGen(setupAction =>
{
    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        setupAction.SwaggerDoc(
            $"{description.GroupName}",
            new OpenApiInfo
            {
                Title = "Restaurant Management API",
                Version = description.ApiVersion.ToString()
            }
            );
    }
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    setupAction.IncludeXmlComments(xmlCommentsFullPath);
});

builder.Services.AddValidators();
builder.Services.AddValidatorsFromAssemblyContaining<CustomerValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction =>
    {
        var descriptions =apiVersionDescriptionProvider.ApiVersionDescriptions;
        foreach (var description in descriptions)
        {
            setupAction.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();