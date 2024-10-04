using CTaxCalculator.Framework.Utilities.OutServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CTaxCalculator.Framework.Endpoints.Web.Extensions.DI
{
    public static class AddArkaSoftwareServicesExtensions
    {
        public static IServiceCollection AddArkaSoftwareUnitalityServices(
        this IServiceCollection services)
        {
            services.AddTransient<ArkaSoftwareCMPOutServices>();
            return services;
        }
    }
}
