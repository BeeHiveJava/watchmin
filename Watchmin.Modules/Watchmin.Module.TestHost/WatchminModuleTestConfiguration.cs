using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.TestHost;

namespace Watchmin.Module.TestHost;

internal class WatchminModuleTestConfiguration<TConfiguration> : IWatchminModuleBootstrapperConfiguration
    where TConfiguration : class, IWatchminModuleBootstrapperConfiguration, new()
{
    private readonly TConfiguration _configuration = new();

    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.WebHost.UseTestServer();
        _configuration.ConfigureServices(builder);
    }

    public void ConfigureApplication(WebApplication application)
    {
        _configuration.ConfigureApplication(application);
    }
}
