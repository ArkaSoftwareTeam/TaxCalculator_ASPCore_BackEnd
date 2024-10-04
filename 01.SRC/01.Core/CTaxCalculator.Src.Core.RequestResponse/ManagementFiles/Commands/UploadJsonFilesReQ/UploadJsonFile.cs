using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;
using Microsoft.AspNetCore.Http;

namespace CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.UploadJsonFilesReQ
{
    public class UploadJsonFile : ICommand<string>, IWebRequest
    {
        public IFormFile? File { get; set; } 
        public string Path => "api/TaxCalculator/UploadFile/TaxRule_JsonFile";
    }
}
