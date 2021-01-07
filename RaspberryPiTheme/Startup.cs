using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.ResourceManagement;
using OrchardCore.Themes.RaspberryPiTheme.Devices;

namespace OrchardCore.Themes.RaspberryPiTheme
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IResourceManifestProvider, ResourceManifest>();
            serviceCollection.AddSingleton<LedDevice>();
        }
    }
}
