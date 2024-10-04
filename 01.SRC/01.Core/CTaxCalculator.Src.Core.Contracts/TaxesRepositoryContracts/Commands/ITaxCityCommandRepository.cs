using CTaxCalculator.Framework.Core.Contracts.Data.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using Microsoft.AspNetCore.Http;

namespace CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands
{
    public interface ITaxCityCommandRepository:ICommandRepository<City , long>
    {
        Task<City> GetByNameAsync(string Name);
        Task<List<City>> ParseCsvFile(IFormFile file);
        Task<List<City>> ParseJsonFile(IFormFile file);
    }
}
