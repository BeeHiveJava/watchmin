namespace Watchmin.Module.Info.Client.Tests;

public class OperatingSystemTest : WatchminModuleTestBase<Program>
{
    [Test]
    public async Task GetOperatingSystem_WhenCalled_ReturnsOperatingSystem()
    {
        // Arrange
        var client = TestHarness.GetRequestClient<OperatingSystem.Request>();

        // Act
        var response = await client.GetResponse<OperatingSystem.Response>(new OperatingSystem.Request());
        var os = response.Message.OperatingSystem;

        // Assert
        os.Platform.ShouldBe(Environment.OSVersion.Platform.ToString());
        os.Version.ShouldBe(Environment.OSVersion.Version.ToString());
    }
}
