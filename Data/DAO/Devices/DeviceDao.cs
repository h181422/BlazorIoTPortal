using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using IoTPortal.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.DAO.Devices
{
    public class DeviceDao : IDeviceDao
    {

        public void SaveDevice(Device device)
        {
            using (var db = new DataContext())
            {
                db.Database.BeginTransaction();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Devices ON");
                db.Devices.Add(device);
                db.SaveChanges();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Devices OFF");
                db.Database.CommitTransaction();
            }
        }

        public List<Device> GetDevicesFromUser(int userId, bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if (checkPublished)
                    return db.Users.FirstOrDefault(x => x.Id == userId)?.OwnDevices.Where(x => x.Published == published).ToList();
                var user = db.Users.FirstOrDefault(x => x.Id == userId);
                var ownDevs = user.OwnDevices;
                return ownDevs;
            }
        }
        public List<Device> GetDevices(bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if (checkPublished)
                    return db.Devices.Where(x => x.Published == published).ToList();
                return db.Devices.ToList();
            }
        }

        public List<Device> GetDevices(string nameContains, bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if (checkPublished)
                    return db.Devices.Where(x => x.Name.Contains(nameContains) && x.Published == published).ToList();

                /*var device = db.Devices.FirstOrDefault();
                db.Users.FirstOrDefault()?.OwnDevices.Add(device);
                var list = db.Users.FirstOrDefault().OwnDevices;
                System.Diagnostics.Debug.WriteLine(list[0].Id);
                db.SaveChanges();*/
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

        public Device GetDevice(int deviceId, bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if(checkPublished)
                    return db.Devices.FirstOrDefault(x => x.Id == deviceId && published == x.Published);
                return db.Devices.FirstOrDefault(x => x.Id == deviceId);
            }
        }

        public Device GetDevice(string deviceName, bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if(checkPublished)
                    return db.Devices.FirstOrDefault(x => x.Name == deviceName && published == x.Published);
                return db.Devices.FirstOrDefault(x => x.Name == deviceName);
            }
        }

        public Register SetApprove(bool app, int registerId)
        {
            using (var db = new DataContext())
            {
                System.Diagnostics.Debug.WriteLine("Bool: " + app);
                var register = db.Registrations.FirstOrDefault(x => x.Id == registerId);
                register.Approved = app;
                db.SaveChanges();
                return register;
            }
        }

        public List<Register> GetRegisters()
        {
            using (var db = new DataContext())
            {
                return db.Registrations.ToList();
            }
        }

        public Register GetSubscription(int registerId)
        {
            using (var db = new DataContext())
            {
                return db.Registrations.FirstOrDefault(x => x.Id == registerId);
            }
        }
    }
}
