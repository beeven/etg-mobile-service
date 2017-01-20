using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SqlHelper
    {
        public static MicroDataTable ExecuteDataTable(this DbContext context, string sql, params object[] parameters)
        {
            var concurrencyDetector = context.Database.GetService<IConcurrencyDetector>();

            using (concurrencyDetector.EnterCriticalSection())
            {
                var rawSqlCommand = context.Database.GetService<IRawSqlCommandBuilder>().Build(sql, parameters);

                RelationalDataReader query = rawSqlCommand.RelationalCommand.ExecuteReader(context.Database.GetService<IRelationalConnection>(), parameterValues: rawSqlCommand.ParameterValues);

                return MicroDataTableHelper.FillDataTable(query.DbDataReader, 0, int.MaxValue);
            }
        }

        public static MicroDataTable ExecuteDataTable(this DbContext context, string sql, int pageIndex, int pageSize, params object[] parameters)
        {
            var concurrencyDetector = context.Database.GetService<IConcurrencyDetector>();

            using (concurrencyDetector.EnterCriticalSection())
            {
                var rawSqlCommand = context.Database.GetService<IRawSqlCommandBuilder>().Build(sql, parameters);

                RelationalDataReader query = rawSqlCommand.RelationalCommand.ExecuteReader(context.Database.GetService<IRelationalConnection>(), parameterValues: rawSqlCommand.ParameterValues);

                return MicroDataTableHelper.FillDataTable(query.DbDataReader, 0, int.MaxValue);
            }
        }
    }
}
