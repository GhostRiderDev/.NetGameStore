using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace config;

public static class SwaggerConfig
{
  public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
  {
    services.AddSwaggerGen(options =>
    {
      options.SwaggerDoc("v1", new OpenApiInfo
      {
        Version = "v1",
        Title = "Game Store API",
        Description = "A ASP.NET web API Game Store Management",
        TermsOfService = new Uri($"https://localhost:5059/games"),
        Contact = new OpenApiContact
        {
          Name = "Example Contact",
          Url = new Uri("https://localhost:5059/games")
        },
        License = new OpenApiLicense
        {
          Name = "MIT",
          Url = new Uri("https://example.com/license")
        }
      });

      // using System.Reflection;
      var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
      options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

      options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        In = ParameterLocation.Header,
        Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
      });

      options.AddSecurityRequirement(new OpenApiSecurityRequirement {
          {
              new OpenApiSecurityScheme {
                  Reference = new OpenApiReference {
                      Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                  }
              },
              new string[] {}
          }
      });
    });
    return services;
  }
}