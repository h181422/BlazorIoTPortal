using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IoTPortal.Client.Data;

namespace IoTPortal.Model
{
    public abstract class UserApiBase : IUserApi
    {
        private HttpClient client;

        protected HttpClient Client
        {
            set { client = value; }
        }

        public async Task<IEnumerable<IoTUser>> GetUsersAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await client.GetAsync($"user/all");
                var usersJson = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<List<IoTUser>>(usersJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return users;
            }
        }
        
        public async Task<IoTUser> Login(string username, string password)
        {
            var content = new StringContent(JsonSerializer.Serialize(new IoTUser(){Username = username, Password = password, Email = "", Id = 0,
                    OwnDevices = new List<Device>(), SubscribedDevices = new List<Register>()}),
                Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"user/login", content);
            var userJson = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<IoTUser>(userJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            if (user != null)
            {
                AuthData.Username = username;
                AuthData.Password = password;
            }
            return user;
        }

        public abstract void SaveAuth(string username, string password);

        public abstract (string Username, string Password) GetAuth();

        public async Task PostUser(IoTUser user)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync($"user", content);
            }
        }

        public async Task<IoTUser> GetUserAsync(int userId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"user/{userId}");
                var usersJson = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<IoTUser>(usersJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return user;
            }
        }

        public async Task<IoTUser> GetUserAsync(string username)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"user/{username}");
                var usersJson = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<IoTUser>(usersJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return user;
            }
        }

        public async Task<IEnumerable<Register>> GetSubscribedDevicesAsync(int userId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"user/subscribedDevs/{userId}");
                var registerJson = await response.Content.ReadAsStringAsync();
                var registers = JsonSerializer.Deserialize<List<Register>>(registerJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return registers;
            }
        }
        public async Task<bool> Unsubscribe(int userId, int deviceId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"user/unsubscribe/{userId}/{deviceId}/");
                var boolJson = await response.Content.ReadAsStringAsync();
                var bol = JsonSerializer.Deserialize<bool>(boolJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return bol;
            }
        }
    }
}
