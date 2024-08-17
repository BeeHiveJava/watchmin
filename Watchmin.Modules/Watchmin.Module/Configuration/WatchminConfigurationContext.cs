using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace Watchmin.Module.Configuration;

public static class WatchminConfigurationContext
{
    public record Services(
        IReadOnlySet<Assembly> Assemblies,
        WebApplicationBuilder WebApplicationBuilder
    );

    public record Application(
        IReadOnlySet<Assembly> Assemblies,
        WebApplication WebApplication
    );
}
