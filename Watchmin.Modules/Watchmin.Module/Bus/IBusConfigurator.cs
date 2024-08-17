using MassTransit;

namespace Watchmin.Module.Bus;

public interface IBusConfigurator
{
    void Configure(IBusRegistrationConfigurator configurator);
}
