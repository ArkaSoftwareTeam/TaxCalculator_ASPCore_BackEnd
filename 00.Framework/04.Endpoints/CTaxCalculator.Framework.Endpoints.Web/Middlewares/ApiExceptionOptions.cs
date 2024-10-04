using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CTaxCalculator.Framework.Endpoints.Web.Middlewares
{
    public class ApiExceptionOptions
    {
        public Action<HttpContext, Exception, ApiError>? AddResponseDetails { get; set; }
        public Func<Exception, LogLevel>? DetermineLogLevel { get; set; }
    }
}
