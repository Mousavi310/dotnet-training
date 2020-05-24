using System;
using Microsoft.Extensions.Primitives;

namespace ConfigurationProviders.SqlServer
{
    public interface ISqlServerWatcher : IDisposable
    {
        IChangeToken Watch();
    }
}
