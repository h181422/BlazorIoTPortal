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
                // CURRENT USER HERE
                db.Devices.Add(device);
                var user = db.Users.Where(b => b.Id == 1).Include(b => b.OwnDevices).FirstOrDefault();
                user.OwnDevices.Add(device);
                db.SaveChanges();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Devices OFF");
                db.Database.CommitTransaction();

            }
        }

        public List<Device> GetDevicesFromUser(int userId, bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.Where(b => b.Id == userId).Include(b => b.OwnDevices).FirstOrDefault();
                var ownDevs = user.OwnDevices;
                if (checkPublished)
                {
                    var publishedDevices = new List<Device>();
                    foreach (var device in ownDevs)
                    {
                        if (device.Published)
                            publishedDevices.Add(device);
                    }
                    return publishedDevices;
                }
                System.Diagnostics.Debug.WriteLine("Own devices: " + ownDevs.Count);
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
                return db.Devices.Where(x => x.Name.Contains(nameContains)).ToList();
            }
        }

        public bool RemoveDevice(int deviceId)
        {
            RemoveRegister(deviceId);
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

        public bool RemoveRegister(int deviceId)
        {
            using (var db = new DataContext())
            {
                var register = db.Registrations.FirstOrDefault(x => x.Dev.Id == deviceId);
                if (register == null)
                    return false;
                db.Registrations.Remove(register);
                db.SaveChanges();
            }

            return true;
        }

        public Device GetDevice(int deviceId, bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if (checkPublished)
                    return db.Devices.FirstOrDefault(x => x.Id == deviceId && published == x.Published);
                return db.Devices.FirstOrDefault(x => x.Id == deviceId);
            }
        }

        public Device GetDevice(string deviceName, bool checkPublished = false, bool published = true)
        {
            using (var db = new DataContext())
            {
                if (checkPublished)
                    return db.Devices.FirstOrDefault(x => x.Name == deviceName && published == x.Published);
                return db.Devices.FirstOrDefault(x => x.Name == deviceName);
            }
        }

        public Register SetApproved(bool app, int registerId)
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
                return db.Registrations.Include(b => b.Dev).Include(b => b.User).ToList();
            }
        }

        public Register GetSubscription(int registerId)
        {
            using (var db = new DataContext())
            {
                return db.Registrations.FirstOrDefault(x => x.Id == registerId);
            }
        }

        public Device SubscribeToDevice(int userId, int deviceId)
        {
            using (var db = new DataContext())
            {
                var device = GetDevice(deviceId);
                var user = db.Users.FirstOrDefault(x => x.Id == 1);
                var register = new Register();
                register.Id = getNextRegisterId();
                register.Approved = false;
                register.Dev = device;
                register.User = user;
                register.Time = System.DateTime.Now.ToString();
                db.Database.BeginTransaction();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Registrations ON");
                db.Database.ExecuteSqlCommand("INSERT INTO Registrations (ID, USERID, DEVID, APPROVED, TIME) VALUES (" + register.Id + "," + user.Id + ", " + device.Id + ",'false', '" + register.Time + "')");
                db.SaveChanges();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Registrations OFF");
                db.Database.CommitTransaction();

                return device;
            }
        }

        public int getNextRegisterId()
        {
            using (var db = new DataContext())
            {
                var ids = db.Registrations.Select(u => u.Id).ToList();
                var id = 0;
                while (true)
                {
                    if (ids.Contains(id))
                    {
                        id++;
                    }
                    else
                    {
                        return id;
                    }
                }
            }
        }

        public Device SetPublished(int deviceId, bool isPublished)
        {
            using (var db = new DataContext())
            {
                var device = db.Devices.FirstOrDefault(x => x.Id == deviceId);
                device.Published = isPublished;
                db.SaveChanges();
                return device;
            }
        }
    }
}
