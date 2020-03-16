using Car.App.Management.Services.Api.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Car.App.Management.Services.Api
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
            // Setting DBContexts
            services.AddDatabaseSetup(Configuration);

            // ASP.NET Identity Settings & JWT
            services.AddIdentitySetup(Configuration);

            // WebAPI Config
            services.AddControllers();

            // AutoMapper Settings
            services.AddAutoMapperSetup();

            // Authorization
            services.AddAuthSetup(Configuration);

            // Swagger Config
            services.AddSwaggerSetup();

            // .NET Native DI Abstraction
            services.AddDependencyInjectionSetup();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();

        }
    }
}
