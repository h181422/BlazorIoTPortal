using IoTPortal.Model;
using IoTPortal.Model.Controllers;
using System;
using System.Net.Http;

namespace IoTPortal.Client.Data
{
    public class UserApi : UserApiBase
    {
        public UserApi(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            Client = client;
        }
    }
}
