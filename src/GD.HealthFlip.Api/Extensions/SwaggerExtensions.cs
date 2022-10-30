using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GD.HealthFlip.Api;

public static class SwaggerConfig
{
  public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
  {
    services.AddVersionedApiExplorer(options =>
    {
      options.GroupNameFormat = "'v'VVV";
      options.SubstituteApiVersionInUrl = true;
    });
    services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
    services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());

    services.AddSwaggerGen(c =>
    {
      c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
          Description = "Insert your bearer token as: Bearer {your token}",
          Name = "Authorization",
          Scheme = "Bearer",
          BearerFormat = "JWT",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey
        });

      c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
          },
          Array.Empty<string>()
        }
      });
    });

    return services;
  }

  public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
  {
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
      c.DocumentTitle = "despesas-integradas-api";
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });

    return app;
  }
}

public class SwaggerDefaultValues : IOperationFilter
{
  public void Apply(OpenApiOperation operation, OperationFilterContext context)
  {
    var apiDescription = context.ApiDescription;
    operation.Deprecated |= apiDescription.IsDeprecated();

    if (operation.Parameters == null)
      return;

    foreach (var parameter in operation.Parameters)
    {
      var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);
      if (parameter.Description == null)
      {
        parameter.Description = description.ModelMetadata?.Description;
      }

      if (parameter.Schema.Default == null && description.DefaultValue != null)
      {
        parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());
      }

      parameter.Required |= description.IsRequired;
    }
  }
}

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
  private readonly IApiVersionDescriptionProvider _provider;

  public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

  public void Configure(SwaggerGenOptions options)
  {
    // add a swagger document for each discovered API version
    // note: you might choose to skip or document deprecated API versions differently
    foreach (var description in _provider.ApiVersionDescriptions)
    {
      options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
    }
  }

  private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
  {
    var info = new OpenApiInfo() { Title = "despesas-integradas-api", Version = description.ApiVersion.ToString(), };

    if (description.IsDeprecated)
    {
      info.Description += " This API version has been deprecated.";
    }

    return info;
  }
}
