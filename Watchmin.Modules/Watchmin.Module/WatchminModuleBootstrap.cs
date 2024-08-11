namespace Watchmin.Module;

public static class WatchminModuleBootstrap
{
    public static Task BootstrapAsync<TConfiguration>(string[]? args = null)
        where TConfiguration : class, IWatchminModuleBootstrapperConfiguration, new() =>
        new WatchminModuleBootstrapper<TConfiguration>(args).RunAsync();
}
