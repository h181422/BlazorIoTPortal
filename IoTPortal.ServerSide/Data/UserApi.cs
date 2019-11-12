using IoTPortal.Model;
using System;
using System.Net.Http;

namespace IoTPortal.ServerSide.Data
{
    public class UserApi : UserApiBase
    {
        public UserApi(IHttpClientFactory factory)
        {
            var client = factory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            Client = client;
        }
    }
}