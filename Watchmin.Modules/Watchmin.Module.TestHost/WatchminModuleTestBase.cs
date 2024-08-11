using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Watchmin.Module.TestHost;

public abstract class WatchminModuleTestBase<T> : WatchminModuleTestBase
    where T : WatchminModuleBootstrapperConfiguration, new()
{
    protected override WatchminModuleBootstrapper Bootstrapper => new WatchminModuleBootstrapper<WatchminModuleTestConfiguration<T>>();
}

public abstract class WatchminModuleTestBase
{
    protected HttpClient? Client { get; private set; }
    protected TestServer? Server { get; private set; }

    [SetUp]
    public void Setup()
    {
        var application = Create();
        application.Start();

        Server = application.GetTestServer();
        Client = application.GetTestClient();
    }

    [TearDown]
    public void Teardown()
    {
        Client?.Dispose();
        Server?.Dispose();
    }

    protected virtual WebApplication Create() =>
        Bootstrapper.Create();

    protected virtual WatchminModuleBootstrapper Bootstrapper =>
        new WatchminModuleBootstrapper<WatchminModuleTestConfiguration>();
}
