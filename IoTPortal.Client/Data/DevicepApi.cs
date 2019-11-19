using IoTPortal.Model;
using System;
using System.Net.Http;
using System.Text;

namespace IoTPortal.Client.Data
{
    public class DeviceApi : DeviceApiBase
    {
        public DeviceApi(HttpClient client)
        {
            if (client.BaseAddress != new Uri("http://localhost:5000/api/")) { }
                client.BaseAddress = new Uri("http://localhost:5000/api/");
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            //if (client.DefaultRequestHeaders.Authorization==null)
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            Client = client;
        }
    }
}
