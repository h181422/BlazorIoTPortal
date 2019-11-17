using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using IoTPortal.Components;
using IoTPortal.Model;

namespace IoTPortal.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var httpClient = new HttpClient {BaseAddress = new Uri("http://localhost:5000/api/")};
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            services.AddSingleton<HttpClient>(httpClient);

            //Inject APIs
            services.AddSingleton<IDeviceApi, DeviceApi>();
            services.AddSingleton<IUserApi, UserApi>();
        }
            
        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
