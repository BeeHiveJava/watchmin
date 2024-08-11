using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.TestHost;

namespace Watchmin.Module.TestHost;

internal class WatchminModuleTestConfiguration<T> : WatchminModuleTestConfiguration
    where T : class, IWatchminModuleBootstrapperConfiguration, new()
{
    private readonly T _configuration = new();

    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        base.ConfigureServices(builder);
        _configuration.ConfigureServices(builder);
    }

    public override void ConfigureApplication(WebApplication application)
    {
        base.ConfigureApplication(application);
        _configuration.ConfigureApplication(application);
    }
}

internal class WatchminModuleTestConfiguration : IWatchminModuleBootstrapperConfiguration {
    public virtual void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.WebHost.UseTestServer();
    }

    public virtual void ConfigureApplication(WebApplication application)
    {
    }
}
