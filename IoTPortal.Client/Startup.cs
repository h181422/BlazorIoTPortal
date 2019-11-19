using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using IoTPortal.Components;
using IoTPortal.Model;
using IoTPortal.Client.Data;
using Microsoft.AspNetCore.Components.Authorization;

namespace IoTPortal.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDeviceApi, DeviceApi>();
            services.AddSingleton<IUserApi, UserApi>();
            services.AddSingleton<IUserApi, UserApi>();

            //services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
