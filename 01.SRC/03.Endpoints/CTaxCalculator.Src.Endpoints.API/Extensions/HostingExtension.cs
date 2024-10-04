using ArkaSoftware.Extensions.Caching.Distributed.InMemory.Extensions.DI;
using ArkaSoftware.Extensions.ObjectMappers.AutoMapper.Extensions;
using ArkaSoftware.Extensions.Serializers.Microsoft.Extensions.DI;
using ArkaSoftware.Extensions.Translations.Parrot.Extensions.DI;
using ArkaSoftware.Extensions.UsersManagement.Extensions.DI;
using ArkaSoftware.Utilities.Authentication.APIAuthentication.Extensions.DependencyInjection;
using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.ApplicationServices.Events;
using CTaxCalculator.Framework.Core.ApplicationServices.Queries;
using CTaxCalculator.Framework.Endpoints.Web.Extensions.DI;
using CTaxCalculator.Framework.Endpoints.Web.Extensions.ModelBinding;
using CTaxCalculator.Framework.Infra.Data.SQLCommands.Interceptors;
using CTaxCalculator.Src.Endpoints.API.CustomDecorators;
using CTaxCalculator.Src.Endpoints.API.DI.JWT;
using CTaxCalculator.Src.Endpoints.API.DI.Swaggers.Extensions;
using CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Common;
using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Common;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CTaxCalculator.Src.Endpoints.API.Extensions
{
    public static class HostingExtension
    {
        public static WebApplication ConfigureService(this WebApplicationBuilder builder)
        {
            IConfiguration configuration = builder.Configuration;
            string connectionString = builder.Configuration["ConnectionStrings:CommandLocalDB_ConnectionString"]!;
            builder.Services.AddNonValidatingValidator();
            
            builder.Services.AddArkaSoftwareMicrosoftSerializer();
            builder.Services.AddArkaSoftwareInMemoryCaching();
            builder.Services.AddArkaSoftwareParrotTranslator(configuration, "ParrotTranslator");
            builder.Services.AddNonValidatingValidator();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddArkaSoftwareAutoMapperProfiles(configuration, "AutoMapper");

            builder.Services.AddArkaSoftwareWebUserInfoService(configuration, "WebUserInfo", true);

            builder.Services.AddSingleton<CommandDispatcherDecorator, CustomCommandDecorator>();
            builder.Services.AddSingleton<QueryDispatcherDecorator, CustomQueryDecorator>();
            builder.Services.AddSingleton<EventDispatcherDecorator, CustomEventDecorator>();
            builder.Services.AddArkaSoftwareDependencies(configuration, "CTaxCalculator");
            builder.Services.AddDbContext<CTaxCalculatorCommandDbContext>(options =>
            {
                options.UseSqlServer(connectionString)
                .AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor());
            });

            builder.Services.AddDbContext<CTaxCalculatorQueryDbContext>(options =>
            {
                options.UseSqlServer(connectionString)
                .AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor());
            });
            builder.Services.AddSecurityDependencies(configuration);
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    var serviceProvider = builder.Services.BuildServiceProvider();
            //    var tokenValidationParameters = serviceProvider.GetRequiredService<TokenValidationParameters>();
            //    options.TokenValidationParameters = tokenValidationParameters;
            //});

            builder.Services.AddArkaSoftwareApiCore(configuration, "CTaxCalculator");

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddArkaSoftwareApiAuthentication(configuration, "OAuth");
            builder.Services.AddSwagger(configuration, "Swagger");
            builder.Services.AddSignalR();
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseMafiaGameApiExceptionHandler();
            app.UseSerilogRequestLogging();
            app.UseSwaggerUI("Swagger");
            app.UseStatusCodePages();
            app.UseCors(delegate (CorsPolicyBuilder builder)
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }

    }
}
