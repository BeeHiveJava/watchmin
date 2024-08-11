using Microsoft.AspNetCore.Builder;

namespace Watchmin.Module;

public abstract class WatchminModuleBootstrapperConfiguration : IWatchminModuleBootstrapperConfiguration
{
    public virtual void ConfigureServices(WebApplicationBuilder builder)
    {
    }

    public virtual void ConfigureApplication(WebApplication application)
    {
    }
}

public interface IWatchminModuleBootstrapperConfiguration
{
    void ConfigureServices(WebApplicationBuilder builder);

    void ConfigureApplication(WebApplication application);
}

