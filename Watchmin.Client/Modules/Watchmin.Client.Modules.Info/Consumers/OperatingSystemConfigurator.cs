using MassTransit;
using Watchmin.Module.Bus;

namespace Watchmin.Module.Info.Client.Consumers;

internal class OperatingSystemConfigurator : IBusConfigurator
{
    public void Configure(IBusRegistrationConfigurator configurator)
    {
        configurator.AddConsumer<OperatingSystemConsumer>().Endpoint(endpoint => endpoint.Name = "OperatingSystem");
        configurator.AddRequestClient<OperatingSystem.Request>(new Uri("exchange:OperatingSystem"));
    }
}
