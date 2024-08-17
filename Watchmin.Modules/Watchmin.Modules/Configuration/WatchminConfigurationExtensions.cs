using Watchmin.Modules.Common;

namespace Watchmin.Modules.Configuration;

internal static class WatchminConfigurationExtensions
{
    public static void ConfigureFromAssembly(this WatchminConfigurationContext.Services context)
    {
        foreach (var configuration in context.Assemblies.GetInstances<IWatchminConfiguration>())
            configuration.ConfigureServices(context);
    }

    public static void ConfigureFromAssembly(this WatchminConfigurationContext.Application context)
    {
        foreach (var configuration in context.Assemblies.GetInstances<IWatchminConfiguration>())
            configuration.ConfigureApplication(context);
    }
}
