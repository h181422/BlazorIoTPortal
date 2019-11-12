using System.Collections.Generic;

namespace Data.DAO.Device
{
    public interface IDeviceDao
    {
        void SaveDevice(IoTPortal.Model.Device device);
        bool RemoveDevice(int deviceId);
        List<IoTPortal.Model.Device> GetDevicesFromUser(int userId);
        List<IoTPortal.Model.Device> GetDevices();
        
        IoTPortal.Model.Device GetDevice(int deviceId);
        IoTPortal.Model.Device GetDevice(string deviceName);
    }
}
