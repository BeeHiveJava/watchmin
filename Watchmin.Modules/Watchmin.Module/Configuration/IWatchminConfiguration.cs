namespace Watchmin.Module.Configuration;

public interface IWatchminConfiguration
{
    void ConfigureServices(WatchminConfigurationContext.Services context);

    void ConfigureApplication(WatchminConfigurationContext.Application context);
}
