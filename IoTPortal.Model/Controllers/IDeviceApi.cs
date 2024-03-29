﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTPortal.Model
{
    public interface IDeviceApi
    {
        Task<IEnumerable<Device>> GetDevicesAsync();
        Task<IEnumerable<Device>> GetDevicesFromUser(int userId);

        Task<IEnumerable<Device>> GetPublishedDevicesAsync(string searchTerm);

        Task<Device> GetDeviceAsync(int deviceId);

        Task PostDevice(Device device, int userId);

        Task<Register> SetApproved(bool app, int registerId);

        Task<IEnumerable<Register>> GetRequestsAsync(int userId);

        Task<Register> GetSubscriptionAsync(int registerId);

        Task<bool> DeleteDeviceAsync(int deviceId);

        Task<Device> SubscribeToDeviceAsync(int userId, int deviceId);

        Task<Device> SetPublishedAsync(int deviceId, bool isPublished);



    }
}
