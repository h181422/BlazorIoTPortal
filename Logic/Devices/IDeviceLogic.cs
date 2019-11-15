using System.Collections.Generic;
using IoTPortal.Model;

namespace Logic.Devices
{
    public interface IDeviceLogic
    {
        bool RemoveDevice(int deviceId);
        void SaveDevice(Device device);
        List<Device> GetDevicesFromUser(int userId, bool checkPublished = false, bool published = true);
        List<Device> GetDevices(bool checkPublished = false, bool published = true);
        Device GetDevice(int deviceId, bool checkPublished = false, bool published = true);
        Device GetDevice(string deviceName, bool checkPublished = false, bool published = true);
        List<Device> GetDevices(string nameContains, bool checkPublished = false, bool published = true);
        Register SetApprove(bool app, int registerId);
        List<Register> GetRequests(int userId);
        Register GetSubscription(int registerId);
    }
}
