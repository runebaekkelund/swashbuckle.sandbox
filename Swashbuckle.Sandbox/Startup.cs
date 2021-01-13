using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Swashbuckle.Sandbox
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Swashbuckle.Sandbox", Version = "v1" });
                
                // Allows descriptions for property schemas that references another schema.
                options.UseAllOfToExtendReferenceSchemas();
                
                // The order in which you include XML comments matter.
                // If Swashbuckle.Model.xml is included first it works as expected.
                // If Swashbuckle.Sandbox.xml is included first does not work.
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Swashbuckle.Sandbox.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Swashbuckle.Model.xml"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swashbuckle.Sandbox v1"));
            }
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
