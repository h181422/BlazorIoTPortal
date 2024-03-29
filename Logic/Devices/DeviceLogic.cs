﻿using System.Collections.Generic;
using Data.DAO.Devices;
using IoTPortal.Model;

namespace Logic.Devices
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

        public List<Device> GetDevicesFromUser(int userId, bool checkPublished = false, bool published = true)
        {
            var devices = _dao.GetDevicesFromUser(userId, checkPublished, published);
            if (devices == null)
            {
                return new List<Device>();
            }
            return devices;
        }

        public List<Device> GetDevices(bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevices(checkPublished, published);
        }

        public Device GetDevice(int deviceId, bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevice(deviceId, checkPublished, published);
        }

        public Device GetDevice(string deviceName, bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevice(deviceName, checkPublished, published);
        }

        public List<Device> GetDevices(string nameContains, bool checkPublished = false, bool published = true)
        {
            return _dao.GetDevices(nameContains, checkPublished, published);
        }

        public Register SetApproved(bool app, int registerId)
        {

            var register = _dao.SetApproved(app, registerId);
            if (app)
            {
                Logic.ServiceBus.SendBus bussen = new Logic.ServiceBus.SendBus();
                bussen.SendMessage(register);
            }
            return register;


        }

        public List<Register> GetRequests(int userId)
        {
            var ownDevices = _dao.GetDevicesFromUser(userId);
            var ids = new List<int>();
            foreach (var dev in ownDevices)
            {
                ids.Add(dev.Id);
            }
            var registers = _dao.GetRegisters();
            List<Register> requests = new List<Register>();
            for (int i = 0; i < registers.Count; i++)
            {
                var register = registers[i];
                var registerDeviceId = register.Dev.Id;
                if (ids.Contains(registerDeviceId))
                {
                    requests.Add(register);
                }
            }
            return requests;
        }

        public Register GetSubscription(int registerId)
        {
            return _dao.GetSubscription(registerId);
        }

        public Device SubscribeToDevice(int userId, int deviceId)
        {
            return _dao.SubscribeToDevice(userId, deviceId);
        }

        public Device SaveDevice(Device device, int userId)
        {
           return _dao.SaveDevice(device, userId);
        }

        public Device SetPublished(int deviceId, bool isPublished)
        {
            return _dao.SetPublished(deviceId, isPublished);
        }
    }
}
