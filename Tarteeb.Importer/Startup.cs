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
