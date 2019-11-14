﻿using System.Collections.Generic;
using Data.DAO.Users;
using IoTPortal.Model;

namespace Logic.Users
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _dao;

        public UserLogic()
        {
            _dao = new UserDao();
        }

        public List<Device> GetSubscribedDevices(int userId)
        {
            var registers = _dao.GetSubscribedDevices(userId);
            List<Device> devices = new List<Device>();
            for (int i = 0; i < registers.Count; i++)
            {
                var register = registers[i];
                var device = register.Dev;
                devices.Add(device);
            }
            return devices;
        }

        public IoTUser GetUser(int userId)
        {
            return _dao.GetUser(userId);
        }

        public IoTUser GetUser(string username)
        {
            return _dao.GetUser(username);
        }

        public List<IoTUser> GetUsers()
        {
            return _dao.GetUsers();
        }

        public bool RemoveUser(int userId)
        {
            return _dao.RemoveUser(userId);
        }

        public void SaveUser(IoTUser user)
        {
            _dao.SaveUser(user);
        }
    }
}