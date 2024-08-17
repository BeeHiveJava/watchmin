using Microsoft.AspNetCore.Builder;

namespace Watchmin.Module;

public class WatchminModuleBootstrapper<TConfiguration>(string[]? args = null)
    where TConfiguration : class, IWatchminModuleBootstrapperConfiguration, new()
{
    private readonly WatchminModuleBootstrapperConfigurationComposite _configuration = new([
        new TConfiguration()
    ]);

    public Task RunAsync()
    {
        return Create().RunAsync();
    }

    public WebApplication Create()
    {
        var application = CreateBuilder().Build();
        _configuration.ConfigureApplication(application);
        return application;
    }

    private WebApplicationBuilder CreateBuilder()
    {
        var builder = WebApplication.CreateBuilder(args ?? []);
        _configuration.ConfigureServices(builder);
        return builder;
    }
}
