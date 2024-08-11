namespace Watchmin.Module.Tests;

public class Test : WatchminModuleTestBase<TestModule>
{
    [Test]
    public async Task DoTest()
    {
        var response = await Client!.GetAsync("/test");
        response.EnsureSuccessStatusCode();

        var msg = await response.Content.ReadAsStringAsync();
        msg.ShouldBe("Test Response!");
    }
}
