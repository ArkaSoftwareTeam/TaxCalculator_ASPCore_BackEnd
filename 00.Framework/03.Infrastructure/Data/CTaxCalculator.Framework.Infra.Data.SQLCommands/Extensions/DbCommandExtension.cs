using System.Data.Common;
using System.Data;
using CTaxCalculator.Framework.Infra.Data.SQLCommands.Extensions;
using CTaxCalculator.Framework.Utilities.OutServices.Extensions;


namespace CTaxCalculator.Framework.Infra.Data.SQLCommands.Extensions
{
    public static class DbCommandExtension
    {
        public static void ApplyCorrectYeKe(this DbCommand command)
        {
            command.CommandText = command!.CommandText.ApplyCorrectYeKe();

            foreach (DbParameter parameter in command.Parameters)
            {
                switch (parameter.DbType)
                {
                    case DbType.AnsiString:
                    case DbType.AnsiStringFixedLength:
                    case DbType.String:
                    case DbType.StringFixedLength:
                    case DbType.Xml:
                        parameter.Value = parameter.Value is DBNull ? parameter.Value : parameter.Value!.ApplyCorrectYeKe();
                        break;
                }
            }
        }
    }
}
