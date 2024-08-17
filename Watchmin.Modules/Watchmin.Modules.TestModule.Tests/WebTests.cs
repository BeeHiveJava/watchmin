using NUnit.Framework;
using Shouldly;
using Watchmin.Modules.TestHost;

namespace Watchmin.Modules.TestModule.Tests;

public class WebTests : WatchminModuleTestBase<Program>
{
    [Test]
    public async Task TestEndpoint_WhenRequested_ReturnsData()
    {
        // Arrange
        var endpoint = new Uri("/test", UriKind.Relative);

        // Act
        var message = await Client.GetAsync(endpoint);
        message.EnsureSuccessStatusCode();

        // Assert
        var response = await message.Content.ReadAsStringAsync();
        response.ShouldBe("Hello World!");
    }
}
