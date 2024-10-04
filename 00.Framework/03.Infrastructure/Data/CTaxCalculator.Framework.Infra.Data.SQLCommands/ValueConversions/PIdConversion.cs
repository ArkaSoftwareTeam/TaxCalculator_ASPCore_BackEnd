using CTaxCalculator.Framework.Core.Domain.ValueOBJs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CTaxCalculator.Framework.Infra.Data.SQLCommands.ValueConversions
{
    public class PIdConversion : ValueConverter<PId, long>
    {
        public PIdConversion() : base(c => c.Value, c => PId.FromLong(c))
        {

        }
    }
}
