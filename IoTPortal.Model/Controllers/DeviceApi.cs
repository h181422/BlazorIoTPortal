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
    public abstract class DeviceApiBase : IDeviceApi
    {
        private HttpClient client;
        private string _baseAddress = "http://localhost:5000/api/";

        protected HttpClient Client
        {
            set => client = value;
        }

        public async Task<bool> DeleteDeviceAsync(int deviceId)
        {
            //var response = await client.GetAsync($"device/delete/{deviceId}");
            var request = new HttpRequestMessage(HttpMethod.Get, _baseAddress + $"device/delete/{deviceId}");
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

        public async Task<Device> GetDeviceAsync(int deviceId)
        {
            var response = await client.GetAsync($"device/{deviceId}");
            var devicesJson = await response.Content.ReadAsStringAsync();
            var device = JsonSerializer.Deserialize<Device>(devicesJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return device;
        }

        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            var response = await client.GetAsync($"device/all");
            var devicesJson = await response.Content.ReadAsStringAsync();
            var devices = JsonSerializer.Deserialize<List<Device>>(devicesJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return devices;
        }

        public async Task<IEnumerable<Device>> GetDevicesFromUser(int userId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _baseAddress+ $"device/user/{userId}");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = await client.SendAsync(request, CancellationToken.None);

            var devicesJson = await response.Content.ReadAsStringAsync();
            var devices = JsonSerializer.Deserialize<List<Device>>(devicesJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return devices;
        }

        public async Task<IEnumerable<Device>> GetPublishedDevicesAsync(string searchTerm)
        {
            //var response = await client.GetAsync($"device/search/{searchTerm}");

            var request = new HttpRequestMessage(HttpMethod.Get, _baseAddress + $"device/search/{searchTerm}");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = await client.SendAsync(request, CancellationToken.None);
            var devicesJson = await response.Content.ReadAsStringAsync();
            var devices = JsonSerializer.Deserialize<List<Device>>(devicesJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return devices;
        }

        public async Task<IEnumerable<Register>> GetRequestsAsync(int userId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _baseAddress + $"device/request/{userId}");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = await client.SendAsync(request, CancellationToken.None);

            var registerJson = await response.Content.ReadAsStringAsync();
            var requests = JsonSerializer.Deserialize<List<Register>>(registerJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return requests;
        }

        public async Task<Register> GetSubscriptionAsync(int registerId)
        {
            var response = await client.GetAsync($"device/register/{registerId}");
            var registerJson = await response.Content.ReadAsStringAsync();
            var register = JsonSerializer.Deserialize<Register>(registerJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return register;
        }

        public async Task PostDevice(Device device, int userId)
        {
            string jsonContent = JsonSerializer.Serialize(device);
            var request = new HttpRequestMessage(HttpMethod.Post, _baseAddress + $"device/post/{userId}");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request, CancellationToken.None);

            var deviceJson = await response.Content.ReadAsStringAsync();
            var dev = JsonSerializer.Deserialize<Device>(deviceJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            //var content = new StringContent(JsonSerializer.Serialize(device), Encoding.UTF8, "application/json");
            //var result = await client.PostAsync($"device", content);
        }

        public async Task<Register> SetApproved(bool app, int registerId)
        {
           // var response = await client.GetAsync($"device/approve/{app}/{registerId}");
            var request = new HttpRequestMessage(HttpMethod.Get, _baseAddress + $"device/approve/{app}/{registerId}");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = await client.SendAsync(request, CancellationToken.None);
            var registerJson = await response.Content.ReadAsStringAsync();
            var register = JsonSerializer.Deserialize<Register>(registerJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return register;
        }

        public async Task<Device> SetPublishedAsync(int deviceId, bool isPublished)
        {
            //var response = await client.GetAsync($"device/publish/{deviceId}/{isPublished}");
            var request = new HttpRequestMessage(HttpMethod.Get, _baseAddress + $"device/publish/{deviceId}/{isPublished}");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = await client.SendAsync(request, CancellationToken.None);
            var devicesJson = await response.Content.ReadAsStringAsync();
            var device = JsonSerializer.Deserialize<Device>(devicesJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return device;
        }

        public async Task<Device> SubscribeToDeviceAsync(int userId, int deviceId)
        {
            //var response = await client.GetAsync($"device/subscribe/{userId}/{deviceId}");
            var request = new HttpRequestMessage(HttpMethod.Get, _baseAddress + $"device/subscribe/{userId}/{deviceId}");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = await client.SendAsync(request, CancellationToken.None);
            var devicesJson = await response.Content.ReadAsStringAsync();
            var device = JsonSerializer.Deserialize<Device>(devicesJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return device;
        }
    }
}
