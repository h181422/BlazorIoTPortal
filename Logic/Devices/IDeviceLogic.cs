using System.Collections.Generic;

namespace Logic.Device
{
    public interface IDeviceLogic
    {
        bool RemoveDevice(int deviceId);
        void SaveDevice(IoTPortal.Model.Device device);
        List<IoTPortal.Model.Device> GetDevicesFromUser(int userId, bool checkPublished = false, bool published = true);
        List<IoTPortal.Model.Device> GetDevices(bool checkPublished = false, bool published = true);
        IoTPortal.Model.Device GetDevice(int deviceId, bool checkPublished = false, bool published = true);
        IoTPortal.Model.Device GetDevice(string deviceName, bool checkPublished = false, bool published = true);
        List<IoTPortal.Model.Device> GetDevices(string nameContains, bool checkPublished = false, bool published = true);
    }
}
