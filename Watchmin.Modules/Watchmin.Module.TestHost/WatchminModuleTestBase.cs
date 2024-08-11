using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.TestHost;

namespace Watchmin.Module.TestHost;

public abstract class WatchminModuleTestBase<TConfiguration>
    where TConfiguration : WatchminModuleBootstrapperConfiguration, new()
{
    protected WebApplication? Application { get; private set; }
    protected HttpClient? Client { get; private set; }
    protected TestServer? Server { get; private set; }

    [SetUp]
    public async Task Setup()
    {
        Application = Bootstrapper.Create();
        await Application.StartAsync();

        Server = Application.GetTestServer();
        Client = Application.GetTestClient();
    }

    [TearDown]
    public async Task Teardown()
    {
        await (Application?.StopAsync() ?? Task.CompletedTask);
        await (Application?.DisposeAsync() ?? ValueTask.CompletedTask);
        Client?.Dispose();
        Server?.Dispose();
    }

    private WatchminModuleBootstrapper<WatchminModuleTestConfiguration<TConfiguration>> Bootstrapper => new();
}
