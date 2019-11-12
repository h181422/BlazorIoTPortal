using System.Collections.Generic;

namespace Data.DAO.Device
{
    public interface IDeviceDao
    {
        void SaveDevice(IoTPortal.Model.Device device);
        bool RemoveDevice(int deviceId);
        List<IoTPortal.Model.Device> GetDevicesFromUser(int userId, bool checkPublished = false, bool published = true);
        List<IoTPortal.Model.Device> GetDevices(bool checkPublished = false, bool published = true);
        List<IoTPortal.Model.Device> GetDevices(string nameContains, bool checkPublished = false, bool published = true);
        IoTPortal.Model.Device GetDevice(int deviceId, bool checkPublished = false, bool published = true);
        IoTPortal.Model.Device GetDevice(string deviceName, bool checkPublished = false, bool published = true);
    }
}
