using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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
            var response = await client.GetAsync($"User/all");
            var usersJson = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<IoTUser>>(usersJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return users;
        }

        public async Task PostUser(IoTUser user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IoTUser> GetUserAsync(int userIdentification)
        {
            var response = await client.GetAsync($"User/{userIdentification}");
            var usersJson = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<IoTUser>(usersJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return user;
        }

        public async Task<IoTUser> GetUserAsync(string username)
        {
            var response = await client.GetAsync($"{username}");
            var usersJson = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<IoTUser>(usersJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return user;
        }

        public async Task<IEnumerable<Device>> GetSubscribedDevicesAsync(int userId)
        {
            var response = await client.GetAsync($"device/subscribed/{userId}");
            var devicesJson = await response.Content.ReadAsStringAsync();
            var devices = JsonSerializer.Deserialize<List<Device>>(devicesJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return devices;
        }
    }
}
