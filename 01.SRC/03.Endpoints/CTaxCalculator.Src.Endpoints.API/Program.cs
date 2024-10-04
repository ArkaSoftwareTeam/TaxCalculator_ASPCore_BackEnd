using ArkaSoftware.Utilities.SeriLogRegisteration.Extensions;
using ArkaSoftware.Utilities.SeriLogRegisteration.Extensions.DependencyInjection;
using CTaxCalculator.Src.Endpoints.API.Extensions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.AddZaminSerilog(options =>
    {
        options.ApplicationName = builder.Configuration.GetValue<string>("ApplicationName")!;
        options.ServiceId = builder.Configuration.GetValue<string>("ServiceId")!;
        options.ServiceName = builder.Configuration.GetValue<string>("ServiceName")!;
        options.ServiceVersion = builder.Configuration.GetValue<string>("ServiceVersion")!;
    }).ConfigureService().ConfigurePipeline();
    app.Run();
});