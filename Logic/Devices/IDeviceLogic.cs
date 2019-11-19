using System.Collections.Generic;
using IoTPortal.Model;

namespace Logic.Devices
{
    public interface IDeviceLogic
    {
        bool RemoveDevice(int deviceId);
        Device SaveDevice(Device device, int userId);
        List<Device> GetDevicesFromUser(int userId, bool checkPublished = false, bool published = true);
        List<Device> GetDevices(bool checkPublished = false, bool published = true);
        Device GetDevice(int deviceId, bool checkPublished = false, bool published = true);
        Device GetDevice(string deviceName, bool checkPublished = false, bool published = true);
        List<Device> GetDevices(string nameContains, bool checkPublished = false, bool published = true);
        Register SetApproved(bool app, int registerId);
        List<Register> GetRequests(int userId);
        Register GetSubscription(int registerId);
        Device SubscribeToDevice(int userId, int deviceId);
        Device SetPublished(int deviceId, bool isPublished);
    }
}
