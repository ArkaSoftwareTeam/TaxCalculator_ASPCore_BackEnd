using CTaxCalculator.Framework.Core.Domain.ValueOBJs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CTaxCalculator.Framework.Infra.Data.SQLCommands.ValueConversions
{
    public class DescriptionConvention : ValueConverter<Description, string>
    {
        public DescriptionConvention() : base(c => c.Value, c => Description.FromString(c))
        {

        }
    }
}
