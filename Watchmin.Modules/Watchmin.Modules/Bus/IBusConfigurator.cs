using MassTransit;

namespace Watchmin.Modules.Bus;

public interface IBusConfigurator
{
    void Configure(IBusRegistrationConfigurator configurator);
}
