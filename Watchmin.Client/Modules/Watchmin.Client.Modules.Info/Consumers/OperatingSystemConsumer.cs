using MassTransit;

namespace Watchmin.Module.Info.Client.Consumers;

internal class OperatingSystemConsumer : IConsumer<OperatingSystem.Request>
{
    public Task Consume(ConsumeContext<OperatingSystem.Request> context)
    {
        var os = new OperatingSystem(Environment.OSVersion.Platform.ToString(), Environment.OSVersion.Version.ToString());
        return context.RespondAsync(new OperatingSystem.Response(os));
    }
}
