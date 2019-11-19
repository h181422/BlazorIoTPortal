using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
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
            var response = await client.GetAsync($"user/all");
            var usersJson = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<IoTUser>>(usersJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return users;
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
            string jsonContent = JsonSerializer.Serialize(user);
            var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + $"user");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request, CancellationToken.None);
        }

        public async Task<IoTUser> GetUserAsync(int userId)
        {
            string jsonContent = "";
            var request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress + $"user/{userId}");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request, CancellationToken.None);

            var usersJson = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<IoTUser>(usersJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return user;
        }

        public async Task<IoTUser> GetUserAsync(string username)
        {
            var response = await client.GetAsync($"user/{username}");
            var usersJson = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<IoTUser>(usersJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return user;
        }

        public async Task<IEnumerable<Register>> GetSubscribedDevicesAsync(int userId)
        {
            var response = await client.GetAsync($"user/subscribedDevs/{userId}");
            var registerJson = await response.Content.ReadAsStringAsync();
            var registers = JsonSerializer.Deserialize<List<Register>>(registerJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return registers;
        }
        public async Task<bool> Unsubscribe(int userId, int deviceId)
        {
            string jsonContent = "";
            var request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress + $"user/unsubscribe/{userId}/{deviceId}/");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request, CancellationToken.None);

            var boolJson = await response.Content.ReadAsStringAsync();
            var bol = JsonSerializer.Deserialize<bool>(boolJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return bol;
        }
    }
}
