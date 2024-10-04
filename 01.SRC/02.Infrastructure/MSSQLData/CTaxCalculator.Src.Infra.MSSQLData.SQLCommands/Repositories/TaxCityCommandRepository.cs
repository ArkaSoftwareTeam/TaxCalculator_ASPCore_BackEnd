using CTaxCalculator.Framework.Infra.Data.SQLCommands.Common;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;
using CTaxCalculator.Src.Core.Domain.UsersAggregate.ValueOBJs;
using CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.CityFileUploadReQ;
using CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Repositories
{
    public class TaxCityCommandRepository : BaseCommandRepository<City, CTaxCalculatorCommandDbContext>, ITaxCityCommandRepository
    {
        public TaxCityCommandRepository(CTaxCalculatorCommandDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<City>> ParseJsonFile(IFormFile file)
        {
            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                var fileContent = await stream.ReadToEndAsync();
                var citiesDto = JsonConvert.DeserializeObject<List<CityDataTransferOBJ>>(fileContent);
                var cities = new List<City>();
                foreach (var cityDto in citiesDto!)
                {
                    var city = new City(new CityName(cityDto.CityName));
                    city.SetId(cityDto.Id);
                    foreach (var taxRuleDto in cityDto.TaxRules)
                    {
                        var taxRuleDateTime = new TaxRuleDateTime(
                            TimeOnly.Parse(taxRuleDto.TaxRuleDateTime!.StartTime),
                            TimeOnly.Parse(taxRuleDto.TaxRuleDateTime.EndTime)
                        );
                        var taxAmount = new Price(taxRuleDto.TaxAmount!.Amount);
                        var taxRule = new TaxRule(taxRuleDateTime, taxAmount);
                        city.AddTaxRule(taxRule);
                    }

                    cities.Add(city);
                }

                return cities;
            }
            
        }

        /// <summary>
        /// This method processes a CSV file and converts its data into domain entities.
        /// The CSV file should contain city and tax rule information.
        /// Each row in the file represents one city and one tax rule.
        /// </summary>
        /// <param name="file">The CSV file uploaded as an IFormFile.</param>
        /// <returns>A list of City objects populated with their respective tax rules.</returns>
        public async Task<List<City>> ParseCsvFile(IFormFile file)
        {
            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                // Dictionary to store cities by their name, preventing duplication
                var cities = new Dictionary<string, City>();
                string? line;
                bool isFirstLine = true;

                // Read and process each line of the CSV file
                while ((line = await stream.ReadLineAsync()) != null)
                {
                    // Skip the first line which typically contains the column headers
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    // Split the line into columns by comma separator
                    var columns = line.Split(',');

                    // Ensure that the line contains the expected number of columns
                    if (columns.Length < 4)
                    {
                        throw new FormatException("Invalid CSV format. Expected at least 4 columns.");
                    }

                    // Parse city name, start time, end time, and tax amount from the columns
                    var cityName = columns[0];
                    var startTime = TimeOnly.Parse(columns[1]);
                    var endTime = TimeOnly.Parse(columns[2]);
                    var amount = decimal.Parse(columns[3]);

                    // Create a new TaxRule object using the parsed data
                    var taxRuleDateTime = new TaxRuleDateTime(startTime, endTime);
                    var taxAmount = new Price(amount);
                    var taxRule = new TaxRule(taxRuleDateTime, taxAmount);

                    // If the city already exists in the dictionary, add the new tax rule to its list
                    if (cities.ContainsKey(cityName))
                    {
                        cities[cityName].AddTaxRule(taxRule);
                    }
                    else
                    {
                        // If the city does not exist, create a new City object and add the tax rule
                        var city = new City(new CityName(cityName));
                        city.AddTaxRule(taxRule);
                        cities.Add(cityName, city);
                    }
                }

                // Return the list of City objects, populated with their tax rules
                return cities.Values.ToList();
            }
        }



        public async Task<City> GetByNameAsync(string Name)
        {
            return _dbContext.Cities.AsEnumerable().FirstOrDefault(x => x.CityName.Value == Name)!;
        }
    }
}
