﻿using Extensions.DependentyInjection.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace CTaxCalculator.Framework.Endpoints.Web.Extensions.DI
{
    public static class Extensions
    {

        public static IServiceCollection AddArkaSoftwareDependencies(this IServiceCollection services, IConfiguration configuration,
            params string[] assemblyNamesForSearch)
        {

            var assemblies = GetAssemblies(assemblyNamesForSearch);
            services.AddArkaSoftwareApplicationServices(assemblies)
                .AddArkaSoftwareDataAccess(assemblies)
                .AddArkaSoftwareUnitalityServices()
                .AddCustomerDependencies(assemblies);
            return services;
        }
        public static IServiceCollection AddCustomerDependencies(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            return services.AddWithTransientLifetime(assemblies, typeof(ITransientLifetime))
                .AddWithScopedLifetime(assemblies, typeof(IScopeLifetime))
                .AddWithSingletonLifetime(assemblies, typeof(ISingletoneLifetime));
        }

        public static IServiceCollection AddWithTransientLifetime(this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch,
            params Type[] assignableTo)
        {
            services.Scan(s => s.FromAssemblies(assembliesForSearch)
                .AddClasses(c => c.AssignableToAny(assignableTo))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
            return services;
        }
        public static IServiceCollection AddWithScopedLifetime(this IServiceCollection services,
           IEnumerable<Assembly> assembliesForSearch,
           params Type[] assignableTo)
        {
            services.Scan(s => s.FromAssemblies(assembliesForSearch)
                .AddClasses(c => c.AssignableToAny(assignableTo))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }

        public static IServiceCollection AddWithSingletonLifetime(this IServiceCollection services,
            IEnumerable<Assembly> assembliesForSearch,
            params Type[] assignableTo)
        {
            services.Scan(s => s.FromAssemblies(assembliesForSearch)
                .AddClasses(c => c.AssignableToAny(assignableTo))
                .AsImplementedInterfaces()
                .WithSingletonLifetime());
            return services;
        }


        private static List<Assembly> GetAssemblies(string[] assemblyName)
        {

            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default!.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                if (IsCandidateCompilationLibrary(library, assemblyName))
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }
            return assemblies;
        }
        private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assemblyName)
        {
            return assemblyName.Any(d => compilationLibrary.Name.Contains(d))
                || compilationLibrary.Dependencies.Any(d => assemblyName.Any(c => d.Name.Contains(c)));
        }

    }
}
