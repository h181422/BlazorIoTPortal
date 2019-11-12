using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IoTPortal.Model;

namespace Data.DAO
{
    public class DeviceDao
    {

        public void SaveDevice(Device device)
        {
            using (var db = new DataContext())
            {
                db.Devices.Add(device);
                db.SaveChanges();
            }
        }

        public List<Device> GetDevicesFromUser(int userId)
        {
            using (var db = new DataContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == userId)?.OwnDevices;
            }
        }
        public List<Device> GetDevices()
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

        public Device GetDevice(int deviceId)
        {
            using (var db = new DataContext())
            {
                return db.Devices.FirstOrDefault(x => x.Id == deviceId);
            }
        }
        
    }
}
