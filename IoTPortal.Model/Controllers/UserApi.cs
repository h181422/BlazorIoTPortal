﻿using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IoTPortal.Model
{
    public class UserApi : IUserApi
    {
        private readonly HttpClient _httpClient;

        public UserApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<IoTUser>> GetUsersAsync()
        {
            var response = await _httpClient.GetAsync($"User/all");
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
            var response = await _httpClient.GetAsync($"User/{userIdentification}");
            var usersJson = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<IoTUser>(usersJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return user;
        }

        public async Task<IoTUser> GetUserAsync(string username)
        {
            var response = await _httpClient.GetAsync($"{username}");
            var usersJson = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<IoTUser>(usersJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return user;
        }

        public async Task<IEnumerable<Device>> GetSubscribedDevicesAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"device/subscribed/{userId}");
            var devicesJson = await response.Content.ReadAsStringAsync();
            var devices = JsonSerializer.Deserialize<List<Device>>(devicesJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return devices;
        }
    }
}
