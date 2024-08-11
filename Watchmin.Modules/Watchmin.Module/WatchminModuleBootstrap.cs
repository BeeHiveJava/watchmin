namespace Watchmin.Module;

public static class WatchminModuleBootstrap
{
    public static Task BootstrapAsync(string[]? args = null, CancellationToken ct = default) =>
        new WatchminModuleBootstrapper().Create(args).StartAsync(ct);

    public static Task BootstrapAsync<T>(string[]? args = null, CancellationToken ct = default)
        where T : class, IWatchminModuleBootstrapperConfiguration, new() =>
        new WatchminModuleBootstrapper<T>().Create(args).StartAsync(ct);
}
