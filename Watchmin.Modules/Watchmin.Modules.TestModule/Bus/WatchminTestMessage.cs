namespace Watchmin.Modules.TestModule.Bus;

public static class WatchminTestMessage
{
    public record Query;

    public record Response(string Message);
}
