using System.Collections.Generic;
using Data.DAO.Devices;
using IoTPortal.Model;

namespace Logic.Devices
{
    public class DeviceLogic : IDeviceLogic
    {
        private readonly IDeviceDao _dao;

        public DeviceLogic()
        {
            _dao = new DeviceDao();
        }

        public bool RemoveDevice(int deviceId)
        {
            return _dao.RemoveDevice(deviceId);
        }

        public void SaveDevice(Device device)
        {
            _dao.SaveDevice(device);
        }

        public List<Device> GetDevicesFromUser(int userId, bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevicesFromUser(userId, checkPublished, published);
        }

        public List<Device> GetDevices(bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevices(checkPublished, published);
        }

        public Device GetDevice(int deviceId, bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevice(deviceId, checkPublished, published);
        }

        public Device GetDevice(string deviceName, bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevice(deviceName, checkPublished, published);
        }

        public List<Device> GetDevices(string nameContains, bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevices(nameContains, checkPublished, published);
        }
    }
}
