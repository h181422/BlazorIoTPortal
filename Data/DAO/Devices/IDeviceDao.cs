using System.Collections.Generic;
using IoTPortal.Model;

namespace Data.DAO.Devices
{
    public interface IDeviceDao
    {
        void SaveDevice(Device device, int userId);
        bool RemoveDevice(int deviceId);
        List<Device> GetDevicesFromUser(int userId, bool checkPublished = false, bool published = true);
        List<Device> GetDevices(bool checkPublished = false, bool published = true);
        List<Device> GetDevices(string nameContains, bool checkPublished = false, bool published = true);
        Device GetDevice(int deviceId, bool checkPublished = false, bool published = true);
        Device GetDevice(string deviceName, bool checkPublished = false, bool published = true);
        Register SetApproved(bool app, int registerId);
        List<Register> GetRegisters();
        Register GetSubscription(int registerId);
        Device SubscribeToDevice(int userId, int deviceId);
        Device SetPublished(int deviceId, bool isPublished);
    }
}
