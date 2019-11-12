using IoTPortal.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IoTPortal.Model
{
    public abstract class DeviceApiBase : IDeviceApi
    {
        private HttpClient client;

        protected HttpClient Client
        {
            set { client = value; }
        }


        public async Task<Device> GetDeviceAsync(string name)
        {
            throw new System.NotImplementedException();
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

        public async Task<IEnumerable<Device>> GetPublishedDevicesAsync(string searchTerm)
        {
            var response = await client.GetAsync($"device/search/{searchTerm}");
            var devicesJson = await response.Content.ReadAsStringAsync();
            var devices = JsonSerializer.Deserialize<List<Device>>(devicesJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return devices;
        }

        public async Task PostDevice(Device device)
        {
            var content = new StringContent(JsonSerializer.Serialize(device), Encoding.UTF8, "application/json");
            var result = await client.PostAsync($"device", content);
        }
    }
}
