using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Framework.Core.RequestResponse.Endpoints
{
    /// <summary>
    /// Interface to represent a web request with a specific endpoint path.
    /// Classes implementing this interface define the path used to call the API endpoint.
    /// </summary>
    public interface IWebRequest
    {
        /// <summary>
        /// Gets the path of the API endpoint that this request targets.
        /// </summary>
        [SwaggerSchema("The path of the API endpoint that this request targets.")]
        string Path { get; }
    }
}
