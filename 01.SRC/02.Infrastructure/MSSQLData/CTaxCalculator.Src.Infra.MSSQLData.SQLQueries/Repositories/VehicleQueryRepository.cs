using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Infra.Data.SQLQueries.QueryRepositories;
using CTaxCalculator.Framework.Utilities.OutServices.Extensions;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.GetVehiclesById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.SearchVehicles;
using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Common;
using Microsoft.EntityFrameworkCore;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Repositories
{
    public class VehicleQueryRepository : BaseQueryRepository<CTaxCalculatorQueryDbContext>, IVehicleQueryRepository
    {
        public VehicleQueryRepository(CTaxCalculatorQueryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<VehicleResQri?> GetVehicleByIdExecuteAsync(GetVehicleByIdQuery query)
        {
            VehicleResQri result = new();
            var queryResult = await _dbContext.Vehicles.AsNoTracking().Include(x => x.City).ToListAsync();

            queryResult = queryResult.Where(x => x.VehicleId == query.VehicleId).ToList();

            result = queryResult.OrderBy(x => x.PlateNumber).Select(x => new VehicleResQri()
            {
                VehicleId = x.VehicleId,
                VehicleType = x.VehicleType.ToString(),
                PlateNumber = x.PlateNumber,
                TotalTaxAmount = x.TotalTaxAmount,
                LastTaxPassageAmount = x.LastTaxPassageAmount,
                City = x.City!.CityName
            }).FirstOrDefault()!;

            return result;
                
        }
            

        public async Task<PagedData<SearchVehiclesResQri>?> SearchVehiclesExecuteAsync(SearchVehiclesQuery query)
        {
            PagedData<SearchVehiclesResQri> result = new();
            var queryResult = await _dbContext.Vehicles.AsNoTracking().Include(x => x.City).ToListAsync();

            if(string.IsNullOrEmpty(query.VehicleType))
                queryResult = queryResult.Where(x => x.VehicleType.ToString() == query.VehicleType).ToList();
            if (!string.IsNullOrEmpty(query.CityName))
                queryResult = queryResult.Where(x => x.City!.CityName.Contains(query.CityName)).ToList();
            if(!string.IsNullOrEmpty(query.PlateNumber))
                queryResult = queryResult.Where(x => x.PlateNumber.Contains(query.PlateNumber)).ToList();

            result.QueryResult = queryResult.OrderBy(x => x.VehicleType)
                .Skip(query.SkipCount)
                .Take(query.PageSize)
                .Select(x => new SearchVehiclesResQri()
                    {
                        VehicleId = x.VehicleId,
                        VehicleType = x.VehicleType.ToString(),
                        PlateNumber = x.PlateNumber,
                        TotalTaxAmount = x.TotalTaxAmount,
                        City = x.City!.CityName
                    }).ToList();

            if (query.NeedTotalCount)
                result.TotalCount = queryResult.Count();

            return result;
        }
    }
}
