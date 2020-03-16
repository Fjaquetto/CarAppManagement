using Car.App.Management.CC.Identity.Authorization;
using Car.App.Management.CC.Identity.Models;
using Car.App.Management.Domain.Interfaces;
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

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
