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

        public string Navn { get { return Navn.ToLower(); } set { Navn = value.ToLower();  } }

        public Task<Device> GetDeviceAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            var response = await client.GetAsync($"device");
            var devicesJson = await response.Content.ReadAsStringAsync();
            var bases = JsonSerializer.Deserialize<List<Device>>(devicesJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return bases;
        }

        public async Task PostDevice(Device device)
        {
            var content = new StringContent(JsonSerializer.Serialize(device), Encoding.UTF8, "application/json");
            await client.PostAsync($"device", content);
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Device>> GetSubscriptionsAsync()
        {
            var response = await client.GetAsync($"subscribed");
            var devicesJson = await response.Content.ReadAsStringAsync();
            var bases = JsonSerializer.Deserialize<List<Device>>(devicesJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return bases;
        }
    }
}
