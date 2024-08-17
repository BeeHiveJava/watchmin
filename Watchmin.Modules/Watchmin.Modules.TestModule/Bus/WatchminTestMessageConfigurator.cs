using MassTransit;
using Watchmin.Modules.Bus;

namespace Watchmin.Modules.TestModule.Bus;

internal class WatchminTestMessageConfigurator : IBusConfigurator
{
    public void Configure(IBusRegistrationConfigurator configurator)
    {
        configurator.AddConsumer<WatchminTestMessageConsumer>().Endpoint(endpoint => endpoint.Name = "TestMessage");
        configurator.AddRequestClient<WatchminTestMessage.Query>(new Uri("exchange:TestMessage"));
    }
}
