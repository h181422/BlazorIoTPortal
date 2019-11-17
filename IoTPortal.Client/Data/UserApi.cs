using IoTPortal.Model;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace IoTPortal.Client.Data
{
    public class UserApi : UserApiBase
    {
        public UserApi(HttpClient client)
        {
            if(client.BaseAddress != new Uri("http://localhost:5000/api/"))
                client.BaseAddress = new Uri("http://localhost:5000/api/");
            Client = client;
        }
    }
}
