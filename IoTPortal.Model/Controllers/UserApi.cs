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
        private string _baseAddress = "http://localhost:5000/api/";

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

        public void Logout()
        {
            AuthData.Id = -1;
            AuthData.Username = "";
            AuthData.Password = "";
        }

        public async Task<IoTUser> Login(string username, string password)
        {
            string jsonContent = JsonSerializer.Serialize(new IoTUser()
            {
                
                Username = username,
                Password = password,
                Email = "",
                Id = 0,
                OwnDevices = new List<Device>(),
                SubscribedDevices = new List<Register>()
            });
            var request = new HttpRequestMessage(HttpMethod.Post, _baseAddress + $"user/login");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request, CancellationToken.None);

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
            AuthData.Id = user.Id;
            return user;
        }

        public abstract void SaveAuth(string username, string password);

        public abstract (string Username, string Password) GetAuth();

        public async Task PostUser(IoTUser user)
        {
            string jsonContent = JsonSerializer.Serialize(user);
            var request = new HttpRequestMessage(HttpMethod.Post, _baseAddress + $"user");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request, CancellationToken.None);
        }

        public async Task<IoTUser> GetUserAsync(int userId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _baseAddress + $"user/{userId}");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
            //var response = await client.GetAsync($"user/subscribedDevs/{userId}");
            var request = new HttpRequestMessage(HttpMethod.Get, _baseAddress + $"user/subscribedDevs/{userId}/");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = await client.SendAsync(request, CancellationToken.None);

            var registerJson = await response.Content.ReadAsStringAsync();
            var registers = JsonSerializer.Deserialize<List<Register>>(registerJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return registers;
        }
        public async Task<bool> Unsubscribe(int userId, int deviceId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _baseAddress + $"user/unsubscribe/{userId}/{deviceId}/");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
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
