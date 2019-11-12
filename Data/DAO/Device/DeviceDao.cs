using System.Collections.Generic;
using System.Linq;
using IoTPortal.Model;

namespace Data.DAO.Device
{
    public class DeviceDao : IDeviceDao
    {

        public void SaveDevice(IoTPortal.Model.Device device)
        {
            using (var db = new DataContext())
            {
                db.Devices.Add(device);
                db.SaveChanges();
            }
        }

        public List<IoTPortal.Model.Device> GetDevicesFromUser(int userId)
        {
            using (var db = new DataContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == userId)?.OwnDevices;
            }
        }
        public List<IoTPortal.Model.Device> GetDevices()
        {
            using (var db = new DataContext())
            {
                return db.Devices.ToList();

            }
        }

        public bool RemoveDevice(int deviceId)
        {
            using (var db = new DataContext())
            {
                var device = db.Devices.FirstOrDefault(x => x.Id == deviceId);
                if (device == null)
                    return false;
                db.Devices.Remove(device);
                db.SaveChanges();
            }

            return true;
        }

        public IoTPortal.Model.Device GetDevice(int deviceId)
        {
            using (var db = new DataContext())
            {
                return db.Devices.FirstOrDefault(x => x.Id == deviceId);
            }
        }

        public IoTPortal.Model.Device GetDevice(string deviceName)
        {
            using (var db = new DataContext())
            {
                return db.Devices.FirstOrDefault(x => x.Name == deviceName);
            }
        }
    }
}
