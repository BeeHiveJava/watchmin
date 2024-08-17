using Microsoft.AspNetCore.Builder;

namespace Watchmin.Module;

public class WatchminModuleBootstrapperConfigurationComposite(IEnumerable<IWatchminModuleBootstrapperConfiguration> configurations) : IWatchminModuleBootstrapperConfiguration
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        foreach (var configuration in configurations)
        {
            configuration.ConfigureServices(builder);
        }
    }

    public void ConfigureApplication(WebApplication application)
    {
        foreach (var configuration in configurations)
        {
            configuration.ConfigureApplication(application);
        }
    }
}
