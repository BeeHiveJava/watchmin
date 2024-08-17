using System.Diagnostics.CodeAnalysis;
using MassTransit;
using MassTransit.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Watchmin.Modules.TestHost;

[ExcludeFromCodeCoverage]
public abstract class WatchminModuleTestBase<TProgram> where TProgram : class
{
    private WebApplicationFactory<TProgram> ApplicationFactory { get; set; } = default!;
    protected TestServer Server => ApplicationFactory.Server;
    protected HttpClient Client => ApplicationFactory.CreateClient();
    protected ITestHarness TestHarness => ApplicationFactory.Services.GetTestHarness();
    protected IServiceProvider ServiceProvider => ApplicationFactory.Services;

    [SetUp]
    public void Setup()
    {
        ApplicationFactory = new WebApplicationFactory<TProgram>().WithWebHostBuilder(Configure);
    }

    [TearDown]
    public async Task Teardown()
    {
        await ApplicationFactory.DisposeAsync();
    }

    private void Configure(IWebHostBuilder builder)
    {
        builder.UseTestServer();
        builder.ConfigureTestServices(collection =>
        {
            ConfigureServices(collection);
            collection.AddMassTransitTestHarness(options =>
            {
                options.SetDefaultRequestTimeout(TimeSpan.FromSeconds(1));
            });
        });
    }

    protected virtual void ConfigureServices(IServiceCollection services)
    {
    }
}
