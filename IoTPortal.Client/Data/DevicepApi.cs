using IoTPortal.Model;
using System;
using System.Net.Http;

namespace IoTPortal.Client.Data
{
    public class DeviceApi : DeviceApiBase
    {
        public DeviceApi(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            Client = client;
        }
    }
}
