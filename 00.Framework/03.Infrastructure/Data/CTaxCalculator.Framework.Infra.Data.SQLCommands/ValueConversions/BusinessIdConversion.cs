using CTaxCalculator.Framework.Core.Domain.ValueOBJs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CTaxCalculator.Framework.Infra.Data.SQLCommands.ValueConversions
{
    public class BusinessIdConversion : ValueConverter<BusinessID, Guid>
    {
        public BusinessIdConversion() : base(c => c.Value, c => BusinessID.FromGuid(c))
        {

        }
    }
}
