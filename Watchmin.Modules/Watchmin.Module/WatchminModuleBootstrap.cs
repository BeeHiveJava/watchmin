using System.Reflection;

namespace Watchmin.Module;

public static class WatchminModuleBootstrap
{
    public static Task BootstrapAsync(Assembly assembly, string[]? args = null) =>
        new WatchminModuleBootstrapper(assembly, args).RunAsync();
}
