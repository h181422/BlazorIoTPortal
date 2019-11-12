using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
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

        public List<IoTPortal.Model.Device> GetDevicesFromUser(int userId, bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if (checkPublished)
                    return db.Users.FirstOrDefault(x => x.Id == userId)?.OwnDevices.Where(x => x.Published == published).ToList();
                return db.Users.FirstOrDefault(x => x.Id == userId)?.OwnDevices;
            }
        }
        public List<IoTPortal.Model.Device> GetDevices(bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if (checkPublished)
                    return db.Devices.Where(x => x.Published == published).ToList();
                return db.Devices.ToList();
            }
        }

        public List<IoTPortal.Model.Device> GetDevices(string nameContains, bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if (checkPublished)
                    return db.Devices.Where(x => x.Name.Contains(nameContains) && x.Published == published).ToList();
                return db.Devices.Where(x=>x.Name.Contains(nameContains)).ToList();
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

        public IoTPortal.Model.Device GetDevice(int deviceId, bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if(checkPublished)
                    return db.Devices.FirstOrDefault(x => x.Id == deviceId && published == x.Published);
                return db.Devices.FirstOrDefault(x => x.Id == deviceId);
            }
        }

        public IoTPortal.Model.Device GetDevice(string deviceName, bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if(checkPublished)
                    return db.Devices.FirstOrDefault(x => x.Name == deviceName && published == x.Published);
                return db.Devices.FirstOrDefault(x => x.Name == deviceName);
            }
        }
    }
}
