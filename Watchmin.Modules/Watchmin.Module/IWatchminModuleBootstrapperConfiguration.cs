using Microsoft.AspNetCore.Builder;

namespace Watchmin.Module;

public interface IWatchminModuleBootstrapperConfiguration
{
    void ConfigureServices(WebApplicationBuilder builder);

    void ConfigureApplication(WebApplication application);
}
