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
    }
}
