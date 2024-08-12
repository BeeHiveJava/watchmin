using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Watchmin.Module.Tests;

public class BootstrapperTest : WatchminModuleTestBase<BootstrapperTestModule>
{
    [Test]
    public void ConfigureServices_ModuleStarted_IsCalled()
    {
        // Arrange
        var key = "TestKey";

        // Act
        var service = Server!.Services.GetKeyedService<string>(key);

        // Assert
        service.ShouldBe("Test Service!");
    }

    [Test]
    public async Task ConfigureApplication_ModuleStarted_IsCalled()
    {
        // Arrange
        var uri = new Uri("/test", UriKind.Relative);

        // Act
        var response = await Client!.GetAsync(uri);
        response.EnsureSuccessStatusCode();

        // Assert
        var msg = await response.Content.ReadAsStringAsync();
        msg.ShouldBe("Test Response!");
    }
}

public class BootstrapperTestModule : WatchminModuleBootstrapperConfiguration
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        base.ConfigureServices(builder);
        builder.Services.AddKeyedSingleton<string>("TestKey", "Test Service!");
    }

    public override void ConfigureApplication(WebApplication application)
    {
        base.ConfigureApplication(application);
        application.MapGet("/test", () => "Test Response!");
    }
}
