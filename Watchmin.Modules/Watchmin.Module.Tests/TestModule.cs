using Microsoft.AspNetCore.Builder;

namespace Watchmin.Module.Tests;

public class TestModule : WatchminModuleBootstrapperConfiguration
{
    public override void ConfigureApplication(WebApplication application)
    {
        application.MapGet("/test", () => "Test Response!");
    }
}
