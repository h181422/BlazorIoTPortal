using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using IoTPortal.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.DAO.Users
{
    public class UserDao : IUserDao
    {
        public List<Register> GetSubscribedDevices(int userId)
        {
            using (var db = new DataContext())
            {
                var registers = db.Users.Include(b => b.SubscribedDevices).FirstOrDefault(x => x.Id == userId)?.SubscribedDevices.ToList();
                if (registers == null)
                    return new List<Register>();
                return registers;

            }
        }

        public IoTUser GetUser(int userId)
        {
            using (var db = new DataContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == userId);
            }
        }

        public IoTUser GetUser(string username)
        {
            using (var db = new DataContext())
            {
                return db.Users.FirstOrDefault(x => x.Username.Equals(username));
            }
        }

        public List<IoTUser> GetUsers()
        {
            using (var db = new DataContext())
            {
                return db.Users.ToList();
            }
        }

        public bool RemoveUser(int userId)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Id == userId);
                if (user == null)
                    return false;
                db.Users.Remove(user);
                db.SaveChanges();
            }

            return true;
        }

        public void SaveUser(IoTUser user)
        {
            using (var db = new DataContext())
            {
                db.Database.BeginTransaction();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Users ON");
                db.Users.Add(user);
                db.SaveChanges();
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Users OFF");
                db.Database.CommitTransaction();  
            }
        }
        public bool Unsubscribe(int userId, int deviceId)
        {
            using (var db = new DataContext())
            {
                var register = db.Registrations.FirstOrDefault(x => x.Dev.Id == deviceId && x.User.Id == userId);
                if (register == null)
                    return false;
                db.Registrations.Remove(register);
                db.SaveChanges();
            }

            return true;
        }
    }
     
}
