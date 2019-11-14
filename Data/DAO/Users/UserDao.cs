using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using IoTPortal.Model;

namespace Data.DAO.Users
{
    public class UserDao : IUserDao
    {
        public List<Register> GetSubscribedDevices(int userId)
        {
            using (var db = new DataContext())
            {
                
            }
            throw new NotImplementedException();
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
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
