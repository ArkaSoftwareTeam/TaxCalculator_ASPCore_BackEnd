using CTaxCalculator.Src.Endpoints.API.DI.Swaggers.Extensions;
using CTaxCalculator.Src.Endpoints.API.DI.Swaggers.Filters;
using CTaxCalculator.Src.Endpoints.API.DI.Swaggers.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace CTaxCalculator.Src.Endpoints.API.DI.Swaggers.Extensions
{
    public static class SwaggerExtensions
    {

        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration, string sectionName)
        {
            var swaggerOption = configuration.GetSection(sectionName).Get<SwaggerOption>();
            if (swaggerOption != null && swaggerOption.SwaggerDoc != null && swaggerOption.Enable == true)
            {
                services.AddSwaggerGen(option =>
                {
                    option.EnableAnnotations();
             
                    option.SwaggerDoc(swaggerOption.SwaggerDoc.Name, new OpenApiInfo
                    {
                        Title = swaggerOption.SwaggerDoc.Title,
                        Version = swaggerOption.SwaggerDoc.Version,
                    });
                    option.ResolveConflictingActions(apiDescription => apiDescription.First());
                    var oAuthOption = configuration.GetSection("OAuth").Get<SwaggerOAuthOption>();
                    if (oAuthOption != null && oAuthOption.Enabled == true)
                    {
                        option.AddSecurityDefinition("Oauth2", new OpenApiSecurityScheme
                        {
                            Name = "Authorization",
                            Description = "Oauth2",
                            BearerFormat = "Bearer <token>",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.OAuth2,
                            Flows = new OpenApiOAuthFlows
                            {
                                AuthorizationCode = new OpenApiOAuthFlow
                                {
                                    AuthorizationUrl = new Uri(oAuthOption.AuthorizationUrl),
                                    TokenUrl = new Uri(oAuthOption.TokenUrl),
                                    Scopes = oAuthOption.Scopes
                                }
                            }
                        });
                        option.OperationFilter<AddParamsToHeader>();
                    }

                });
            }
            return services;
        }


        public static void UseSwaggerUI(this WebApplication app, string sectionName)
        {
            var swaggerOption = app.Configuration.GetSection(sectionName).Get<SwaggerOption>();

            if (swaggerOption != null && swaggerOption.SwaggerDoc != null && swaggerOption.Enable == true)
            {
                app.UseSwagger();
                app.UseSwaggerUI(option =>
                {
                    option.DocExpansion(DocExpansion.None);
                    option.SwaggerEndpoint(swaggerOption.SwaggerDoc.URL, swaggerOption.SwaggerDoc.Title);
                    option.RoutePrefix = string.Empty;
                    option.OAuthUsePkce();
                });
            }
        }



    }
}
