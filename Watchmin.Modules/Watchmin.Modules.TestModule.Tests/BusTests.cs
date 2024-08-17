using NUnit.Framework;
using Shouldly;
using Watchmin.Modules.TestHost;
using Watchmin.Modules.TestModule.Bus;

namespace Watchmin.Modules.TestModule.Tests;

public class BusTests : WatchminModuleTestBase<Program>
{
    [Test]
    public async Task TestMessage_WhenRequested_ReturnsResponse()
    {
        // Arrange
        var client = TestHarness.GetRequestClient<WatchminTestMessage.Query>();

        // Act
        var response = await client.GetResponse<WatchminTestMessage.Response>(new WatchminTestMessage.Query());
        var message = response.Message.Message;

        // Assert
        message.ShouldBe("Hello World!");
    }
}
