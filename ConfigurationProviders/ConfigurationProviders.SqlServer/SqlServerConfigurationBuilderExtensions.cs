using System;
using Microsoft.Extensions.Configuration;

namespace ConfigurationProviders.SqlServer
{
    public static class SqlServerConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddSqlServer(this IConfigurationBuilder builder, 
            string connectionString,
            TimeSpan? refreshInterval = null)
        {
            return builder.Add(new SqlServerConfigurationSource
            {
                ConnectionString = connectionString,
                SqlServerWatcher = refreshInterval.HasValue ? 
                    new SqlServerPeriodicalWatcher(refreshInterval.Value) : null 
            });
        }
    }
}
