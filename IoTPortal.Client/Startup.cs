using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using IoTPortal.Components;
using IoTPortal.Model;
using IoTPortal.Client.Data;

namespace IoTPortal.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Dependency injection
            services.AddSingleton<IDeviceApi, DeviceApi>();
            services.AddSingleton<IUserApi, UserApi>();
        }
            
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
