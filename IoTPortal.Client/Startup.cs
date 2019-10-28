using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using IoTPortal.Components;
using IoTPortal.Model;
using StartshipTraveler.Client.Data;
using StartshipTraveler.Model;

namespace IoTPortal.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Dependency injection
            services.AddSingleton<IDeviceApi, DeviceApi>();
        }
            
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
