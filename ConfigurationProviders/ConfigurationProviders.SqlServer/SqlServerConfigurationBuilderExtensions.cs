using Microsoft.Extensions.Configuration;

namespace ConfigurationProviders.SqlServer
{
    public static class SqlServerConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddSqlServer(this IConfigurationBuilder builder, string connectionString)
        {
            return builder.Add(new SqlServerConfigurationSource{ConnectionString = connectionString});
        }
    }
}
