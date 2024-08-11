using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Watchmin.Module;

public class WatchminModuleBootstrapper<T>(T? configuration = null) : WatchminModuleBootstrapper
    where T : class, IWatchminModuleBootstrapperConfiguration, new()
{
    private readonly T _configuration = configuration ?? new T();

    public override WebApplication Create(string[]? args = null)
    {
        var application = base.Create(args);
        _configuration.ConfigureApplication(application);
        return application;
    }

    public override WebApplicationBuilder CreateBuilder(string[]? args = null)
    {
        var builder = base.CreateBuilder(args);
        _configuration.ConfigureServices(builder);
        return builder;
    }
}

public class WatchminModuleBootstrapper
{
    public virtual WebApplication Create(string[]? args = null)
    {
        var application = CreateBuilder(args).Build();
        return application;
    }

    public virtual WebApplicationBuilder CreateBuilder(string[]? args = null)
    {
        var builder = WebApplication.CreateBuilder(args ?? []);
        return builder;
    }
}
