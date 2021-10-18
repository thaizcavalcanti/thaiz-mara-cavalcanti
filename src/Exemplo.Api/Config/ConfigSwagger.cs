using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Exemplo.Api.Config
{
    public static class ConfigSwagger
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddOpenApiDocument(doc =>
            {
                doc.Title = "API - Exemplo Thaiz";
                doc.Description = "API tem como objetivo demonstrar nível de conhecimento técnico.";
                doc.GenerateExamples = true;
                doc.UseControllerSummaryAsTagDescription = true;
                doc.GenerateXmlObjects = true;
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = "swagger";
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Example");
            });
        }
    }

}

