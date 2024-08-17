using MassTransit;

namespace Watchmin.Modules.TestModule.Bus;

internal class WatchminTestMessageConsumer : IConsumer<WatchminTestMessage.Query>
{
    public Task Consume(ConsumeContext<WatchminTestMessage.Query> context)
    {
        return context.RespondAsync(new WatchminTestMessage.Response("Hello World!"));
    }
}
