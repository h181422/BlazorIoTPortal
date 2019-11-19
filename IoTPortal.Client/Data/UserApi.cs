using IoTPortal.Model;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace IoTPortal.Client.Data
{
    public class UserApi : UserApiBase
    {
        public UserApi(HttpClient client)
        {
            //if(client.BaseAddress != new Uri("http://localhost:5000/api/"))
            //    client.BaseAddress = new Uri("http://localhost:5000/api/");
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            //if(client.DefaultRequestHeaders.Authorization != null)
            //    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            Client = client;
        }

        public override void SaveAuth(string username, string password)
        {
            AuthData.Username = username;
            AuthData.Password = password;
        }
        public override (string Username, string Password) GetAuth()
        {
            return (AuthData.Username, AuthData.Password);
        }
        
    }
}
