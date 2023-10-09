//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Tarteeb.Importer.Brokers.Storages;
using Tarteeb.Importer.Services.Foundations;
using Tarteeb.Importer.Services.Orchestrations;
using Tarteeb.Importer.Services.Processings;
using Tarteeb.Provider.Brokers.Spreadsheets;

namespace Tarteeb.Importer
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<StorageBroker>();
            services.AddTransient<SpreadsheetBroker>();
            services.AddTransient<OrchestrationService>();
            services.AddTransient<SpreadsheetService>();
            services.AddTransient<SpreadsheetProcessingService>();
            services.AddTransient<GroupService>();
            services.AddTransient<GroupProcessingService>();
            services.AddTransient<ApplicantService>();
            services.AddTransient<ProcessingApplicantService>();

            var openApiInfo = new OpenApiInfo
            {
                Title = "Tarteeb.Importer",
                Version = "v1"
            };

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(
                    name: "v1",
                    info: openApiInfo);
            });
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseSwagger();

                applicationBuilder.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json",
                        name: "Tarteeb.Importer v1");
                });
            }

            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseRouting();
            applicationBuilder.UseAuthorization();

            applicationBuilder.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }
    }
}
