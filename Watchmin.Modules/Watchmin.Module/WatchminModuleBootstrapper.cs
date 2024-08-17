using System.Collections.Frozen;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Watchmin.Module.Configuration;

namespace Watchmin.Module;

internal class WatchminModuleBootstrapper(Assembly assembly, string[]? args = null)
{
    public Task RunAsync()
    {
        return Create().RunAsync();
    }

    private WebApplication Create()
    {
        var application = CreateBuilder().Build();
        GetApplicationContext(application).ConfigureFromAssembly();
        return application;
    }

    private WebApplicationBuilder CreateBuilder()
    {
        var builder = WebApplication.CreateBuilder(args ?? []);
        GetBuilderContext(builder).ConfigureFromAssembly();
        return builder;
    }

    private WatchminConfigurationContext.Application GetApplicationContext(WebApplication application) =>
        new(Assemblies, application);

    private WatchminConfigurationContext.Services GetBuilderContext(WebApplicationBuilder builder) =>
        new(Assemblies, builder);

    private IReadOnlySet<Assembly> Assemblies => new[] { GetType().Assembly, assembly }.ToFrozenSet();
}
