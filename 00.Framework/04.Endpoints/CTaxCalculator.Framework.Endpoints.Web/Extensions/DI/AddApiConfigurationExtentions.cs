using CTaxCalculator.Framework.Endpoints.Web.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CTaxCalculator.Framework.Endpoints.Web.Extensions.DI
{
    public static class AddApiConfigurationExtensions
    {
        public static IServiceCollection AddArkaSoftwareApiCore(this IServiceCollection services, IConfiguration configuration, params string[] assemblyNamesForLoad)
        {
            services.AddFluentValidationAutoValidation().AddControllers();
            services.AddArkaSoftwareDependencies(configuration, assemblyNamesForLoad);

            return services;
        }

        public static void UseMafiaGameApiExceptionHandler(this IApplicationBuilder app)
        {

            app.UseApiExceptionHandler(options =>
            {
                options.AddResponseDetails = (context, ex, error) =>
                {
                    if (ex.GetType().Name == typeof(Microsoft.Data.SqlClient.SqlException).Name)
                    {
                        error.Detail = "Exception was a database exception!";
                    }
                };
                options.DetermineLogLevel = ex =>
                {
                    if (ex.Message.StartsWith("cannot open database", StringComparison.InvariantCultureIgnoreCase) ||
                        ex.Message.StartsWith("a network-related", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return LogLevel.Critical;
                    }
                    return LogLevel.Error;
                };
            });

        }
    }
}
