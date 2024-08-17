using System.Reflection;

namespace Watchmin.Modules;

public static class WatchminModuleBootstrap
{
    public static Task BootstrapAsync(Assembly assembly, string[] args) =>
        new WatchminModuleBootstrapper(assembly, args).RunAsync();
}
