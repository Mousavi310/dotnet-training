using Microsoft.Extensions.Configuration;

namespace ConfigurationProviders.SqlServer
{
    public class SqlServerConfigurationSource : IConfigurationSource
    {
        public string ConnectionString { get; set; }
        public ISqlServerWatcher SqlServerWatcher { get; set; }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SqlServerConfigurationProvider(this);
        }
    }
}
