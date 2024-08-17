using MassTransit;
using Watchmin.Module.Common;
using Watchmin.Module.Configuration;

namespace Watchmin.Module.Bus;

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
