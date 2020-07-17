using Car.App.Management.Application.Interfaces;
using Car.App.Management.Application.Services;
using Car.App.Management.CC.Identity.Authorization;
using Car.App.Management.CC.Identity.Models;
using Car.App.Management.Domain.Interfaces;
using Car.App.Management.Infra.Data.Context;
using Car.App.Management.Infra.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Car.App.Management.CC.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICarroAppService, CarroAppService>();
            services.AddScoped<IClienteAppService, ClienteAppService>();

            // Infra - Data
            services.AddScoped<ICarroRepository, CarroRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<CarAppContext>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
