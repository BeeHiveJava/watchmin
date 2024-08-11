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
