using System.Collections.Generic;

namespace Logic.Device
{
    public interface IDeviceLogic
    {
        bool RemoveDevice(int deviceId);
        void SaveDevice(IoTPortal.Model.Device device);
        List<IoTPortal.Model.Device> GetDevicesFromUser(int userId);
        List<IoTPortal.Model.Device> GetDevices();
        IoTPortal.Model.Device GetDevice(int deviceId);
        IoTPortal.Model.Device GetDevice(string deviceName);
    }
}
