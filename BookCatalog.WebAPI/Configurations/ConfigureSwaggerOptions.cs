using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Reflection;

namespace BookCatalog.WebAPI.Configurations
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) =>
            _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                var apiVersion = description.ApiVersion.ToString();
                options.SwaggerDoc(description.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiVersion,
                        Title = $"Book Catalog Web API V.{apiVersion}",
                        Description = "IT INNOVATIONS | Book catalog web API",
                        TermsOfService = new Uri("https://www.itinnovations.ua/"),
                        Contact = new OpenApiContact
                        {
                            Name = "Main dev contact",
                            Email = string.Empty,
                            Url = new Uri("https://t.me/otix78")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "IT INNOVATIONS",
                            Url = new Uri("https://www.itinnovations.ua/")
                        }
                    });

                options.CustomOperationIds(apiDescription =>
                    apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)
                        ? methodInfo.Name
                        : null);
            }
        }
    }
}
