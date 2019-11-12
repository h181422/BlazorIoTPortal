using System.Collections.Generic;
using Data.DAO.Device;

namespace Logic.Device
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

        public void SaveDevice(IoTPortal.Model.Device device)
        {
            _dao.SaveDevice(device);
        }

        public List<IoTPortal.Model.Device> GetDevicesFromUser(int userId, bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevicesFromUser(userId, checkPublished, published);
        }

        public List<IoTPortal.Model.Device> GetDevices(bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevices(checkPublished, published);
        }

        public IoTPortal.Model.Device GetDevice(int deviceId, bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevice(deviceId, checkPublished, published);
        }

        public IoTPortal.Model.Device GetDevice(string deviceName, bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevice(deviceName, checkPublished, published);
        }

        public List<IoTPortal.Model.Device> GetDevices(string nameContains, bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevices(nameContains, checkPublished, published);
        }
    }
}
