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

        public List<IoTPortal.Model.Device> GetDevicesFromUser(int userId)
        {
            return _dao.GetDevicesFromUser(userId);
        }

        public List<IoTPortal.Model.Device> GetDevices()
        {
            return _dao.GetDevices();
        }

        public IoTPortal.Model.Device GetDevice(int deviceId)
        {
            return _dao.GetDevice(deviceId);
        }

        public IoTPortal.Model.Device GetDevice(string deviceName)
        {
            return _dao.GetDevice(deviceName);
        }
    }
}
