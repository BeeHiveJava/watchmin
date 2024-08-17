using MassTransit;
using Watchmin.Modules.Common;
using Watchmin.Modules.Configuration;

namespace Watchmin.Modules.Bus;

internal class Configuration : WatchminConfiguration
{
    public override void ConfigureServices(WatchminConfigurationContext.Services context)
    {
        var enumerable = context.Assemblies.GetInstances<IBusConfigurator>();

        context.WebApplicationBuilder.Services.AddMassTransit(configurator =>
        {
            foreach (var bus in enumerable)
                bus.Configure(configurator);
        });
    }
}
