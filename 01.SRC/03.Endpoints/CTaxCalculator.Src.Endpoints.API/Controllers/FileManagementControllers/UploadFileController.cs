using CTaxCalculator.Framework.Endpoints.Web.Controllers;
using CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.UploadCsvFilesReQ;
using CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.UploadJsonFilesReQ;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CTaxCalculator.Src.Endpoints.API.Controllers.FileManagementControllers
{
    [Route("api/TaxCalculator/Add/[controller]")]
    public class UploadFileController : BaseController
    {

        #region Register a new city with its tax rules using the JSON file uploader
        /// <summary>
        /// Uploads a JSON file containing tax rules for different cities.
        /// </summary>
        /// <remarks>
        /// This API allows users to upload a JSON file that defines tax rules for various cities. 
        /// Each city can have multiple tax rules, specifying a time period and the corresponding tax amount.
        ///
        /// Example JSON Template:
        /// 
        /// <code>
        /// [
        ///   {
        ///     "cityName": "Tehran",
        ///     "TaxRules": [
        ///       {
        ///         "TaxRuleDateTime": {
        ///           "StartTime": "08:00:00",
        ///           "EndTime": "18:00:00"
        ///         },
        ///         "TaxAmount": {
        ///           "Amount": 15000
        ///         }
        ///       },
        ///       {
        ///         "TaxRuleDateTime": {
        ///           "StartTime": "18:00:00",
        ///           "EndTime": "05:00:00"
        ///         },
        ///         "TaxAmount": {
        ///           "Amount": 18000
        ///         }
        ///       }
        ///     ]
        ///   }
        /// ]
        /// </code>
        ///
        /// - **cityName**: Name of the city.
        /// - **TaxRuleDateTime**: The start and end times for when the tax rule applies.
        /// - **TaxAmount**: The amount of tax to be applied during the specified time period.
        ///
        /// This endpoint processes the file and stores the tax rules in the database.
        ///
        /// Ensure that the JSON file is properly formatted to avoid errors.
        /// </remarks>
        /// <param name="jsonFileUploader">The JSON file to upload, encapsulated in the <see cref="UploadJsonFile"/> object.</param>
        /// <response code="200">If the file is successfully uploaded and processed.</response>
        /// <response code="400">If the file format is invalid or an error occurs during processing.</response>
        [HttpPost("TaxRule_JsonFile")]
        [SwaggerOperation(Summary = "Upload a JSON file of tax rules",
                          Description = "This endpoint accepts a JSON file containing tax rules for different cities. Each tax rule includes a time period and the corresponding tax amount.")]
        [SwaggerResponse(200, "File uploaded and processed successfully.")]
        [SwaggerResponse(400, "The file format is invalid, or an error occurred during processing.")]
        public async Task<IActionResult> UploadJsonFile(UploadJsonFile jsonFileUploader)
        {
            return await Create<UploadJsonFile, string>(jsonFileUploader);
        }

        #endregion


        #region Registration of the new city along with its tax laws by uploading the CSV file
        /// <summary>
        /// Uploads a CSV file containing tax rules for different cities.
        /// </summary>
        /// <remarks>
        /// This API allows users to upload a CSV file with the following format:
        /// 
        /// Example CSV Template:
        /// 
        /// <code>
        /// CityName,StartTime,EndTime,Amount
        /// Tehran,08:00:00,18:00:00,15000
        /// Tehran,18:00:00,05:00:00,18000
        /// </code>
        /// 
        /// - **CityName**: The name of the city.
        /// - **StartTime**: Start time for the tax rule (HH:mm:ss).
        /// - **EndTime**: End time for the tax rule (HH:mm:ss).
        /// - **Amount**: The tax amount for the given time period.
        /// 
        /// Ensure that the CSV file is correctly formatted to avoid errors.
        /// </remarks>
        /// <param name="csvFileUploader">The CSV file to upload.</param>
        /// <response code="200">If the file is successfully uploaded and processed.</response>
        /// <response code="400">If the file format is invalid or processing fails.</response>
        [HttpPost("TaxRule_CsvFile")]
        [SwaggerOperation(
            Summary = "Upload CSV file containing tax rules",
            Description = "This endpoint allows users to upload a CSV file, which contains tax rules for different cities, such as time frames and associated tax amounts. " +
                          "The CSV format should have the following structure: " +
                          "\nCityName,StartTime,EndTime,TaxAmount" +
                          "\nFor example: Tehran,08:00:00,18:00:00,15000" +
                          "\nEnsure that the CSV file is correctly formatted to avoid errors."
        )]
        [SwaggerResponse(200, "CSV file successfully uploaded and processed.")]
        [SwaggerResponse(400, "Invalid file format or processing error.")]
        public async Task<IActionResult> UploadCsvFile(UploadCsvFile csvFileUploader)
        {
            return await Create<UploadCsvFile, string>(csvFileUploader);
        }

        #endregion

    }
}
