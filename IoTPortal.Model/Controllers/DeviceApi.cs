using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IoTPortal.Client.Data;

namespace IoTPortal.Model
{
    public abstract class DeviceApiBase : IDeviceApi
    {
        private HttpClient client;

        protected HttpClient Client
        {
            set => client = value;
        }

        public async Task<Device> DeleteDeviceAsync(int deviceId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"device/delete/{deviceId}");
                var devicesJson = await response.Content.ReadAsStringAsync();
                var device = JsonSerializer.Deserialize<Device>(devicesJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return device;
            }
        }

        public async Task<Device> GetDeviceAsync(int deviceId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"device/{deviceId}");
                var devicesJson = await response.Content.ReadAsStringAsync();
                var device = JsonSerializer.Deserialize<Device>(devicesJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return device;
            }
        }

        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"device/all");
                var devicesJson = await response.Content.ReadAsStringAsync();
                var devices = JsonSerializer.Deserialize<List<Device>>(devicesJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return devices;
            }
        }

        public async Task<IEnumerable<Device>> GetDevicesFromUser(int userId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"device/user/{userId}");
                var devicesJson = await response.Content.ReadAsStringAsync();
                var devices = JsonSerializer.Deserialize<List<Device>>(devicesJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return devices;
            }
        }

        public async Task<IEnumerable<Device>> GetPublishedDevicesAsync(string searchTerm)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"device/search/{searchTerm}");
                var devicesJson = await response.Content.ReadAsStringAsync();
                var devices = JsonSerializer.Deserialize<List<Device>>(devicesJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return devices;
            }
        }

        public async Task<IEnumerable<Register>> GetRequestsAsync(int userId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"device/request/{userId}");
                var registerJson = await response.Content.ReadAsStringAsync();
                var requests = JsonSerializer.Deserialize<List<Register>>(registerJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return requests;
            }
        }

        public async Task<Register> GetSubscriptionAsync(int registerId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await client.GetAsync($"device/register/{registerId}");
                var registerJson = await response.Content.ReadAsStringAsync();
                var register = JsonSerializer.Deserialize<Register>(registerJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return register;
            }
        }

        public async Task PostDevice(Device device)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var content = new StringContent(JsonSerializer.Serialize(device), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync($"device", content);
            }
        }

        public async Task<Register> SetApproved(bool app, int registerId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"device/approve/{app}/{registerId}");
                var registerJson = await response.Content.ReadAsStringAsync();
                var register = JsonSerializer.Deserialize<Register>(registerJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return register;
            }
        }

        public async Task<Device> SetPublishedAsync(int deviceId, bool isPublished)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await client.GetAsync($"device/publish/{deviceId}/{isPublished}");
                var devicesJson = await response.Content.ReadAsStringAsync();
                var device = JsonSerializer.Deserialize<Device>(devicesJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return device;
            }
        }

        public async Task<Device> SubscribeToDeviceAsync(int userId, int deviceId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = client.BaseAddress;
                var byteArray = Encoding.ASCII.GetBytes($"{AuthData.Username}:{AuthData.Password}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await httpClient.GetAsync($"device/subscribe/{userId}/{deviceId}");
                var devicesJson = await response.Content.ReadAsStringAsync();
                var device = JsonSerializer.Deserialize<Device>(devicesJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return device;
            }
        }
    }
}
