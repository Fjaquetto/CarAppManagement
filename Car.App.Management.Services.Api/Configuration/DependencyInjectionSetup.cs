using Car.App.Management.CC.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Car.App.Management.Services.Api.Configuration
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
