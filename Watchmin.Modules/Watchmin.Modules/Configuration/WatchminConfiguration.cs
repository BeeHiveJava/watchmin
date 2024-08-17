using System.Diagnostics.CodeAnalysis;

namespace Watchmin.Modules.Configuration;

public abstract class WatchminConfiguration : IWatchminConfiguration
{
    [ExcludeFromCodeCoverage]
    public virtual void ConfigureServices(WatchminConfigurationContext.Services context)
    {
    }

    [ExcludeFromCodeCoverage]
    public virtual void ConfigureApplication(WatchminConfigurationContext.Application context)
    {
    }
}
