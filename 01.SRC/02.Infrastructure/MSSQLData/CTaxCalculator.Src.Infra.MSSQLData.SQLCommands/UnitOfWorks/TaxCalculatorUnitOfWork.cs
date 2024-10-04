using CTaxCalculator.Framework.Infra.Data.SQLCommands.Common;
using CTaxCalculator.Src.Core.Contracts.UnitOfWorkContract;
using CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Common;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.UnitOfWorks
{
    public class TaxCalculatorUnitOfWork : BaseEntityFrameworkUnitOfWork<CTaxCalculatorCommandDbContext>, ITaxUnitOfWork
    {
        //private readonly ITaxCityCommandRepository _cityRepository;
        public TaxCalculatorUnitOfWork(CTaxCalculatorCommandDbContext dbContext) : base(dbContext)
        {
            //_cityRepository = cityRepository;
        }

        //public ITaxCityCommandRepository taxCityCommandRepository
        //{
        //    get { return _cityRepository; }
        //}
    }
}
