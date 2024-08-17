using Microsoft.AspNetCore.Builder;
using Watchmin.Modules.Configuration;

namespace Watchmin.Modules.TestModule.Web;

internal class Configuration : WatchminConfiguration
{
    public override void ConfigureApplication(WatchminConfigurationContext.Application context)
    {
        context.WebApplication.MapGet("/test", () => "Hello World!");
    }
}
