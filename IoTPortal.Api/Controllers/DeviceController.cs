﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IoTPortal.UI.Server.Data;
using IoTPortal.Model;
using System.Linq;
using Logic.Devices;

namespace IoTPortal.UI.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceLogic _deviceLogic;

        public DeviceController()
        {
            _deviceLogic = new DeviceLogic();
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Device> GetDevices() => _deviceLogic.GetDevices("", false, true);

        [HttpGet]
        [Route("{deviceName}")]
        public IActionResult GetDevice([FromRoute] string deviceName)
        {
            var deviceObj = _deviceLogic.GetDevice(deviceName);
            if (deviceObj == null)
                return NotFound();

            return Ok(deviceObj);
        }

        [HttpGet]
        [Route("search/{searchTerm}")]
        public IEnumerable<Device> GetSearchDevices([FromRoute] string searchTerm) =>
            _deviceLogic.GetDevices(searchTerm, true, true);

        [HttpGet]
        [Route("search")]
        public IEnumerable<Device> GetPublishedDevices() =>
            _deviceLogic.GetDevices(checkPublished: true, true);

        [HttpDelete]
        [Route("{deviceId}")]
        public IActionResult GetPublishedDevice([FromRoute] int deviceId) =>
            Ok(_deviceLogic.GetDevices(true, true).Where(x=>deviceId == x.Id));

        [HttpGet]
        [Route("published")]
        public IActionResult GetPublishedDevice()
        {
            var devices = SampleData.Devices.Where(b => b.Published);

            if (devices == null)
            {
                return NotFound();
            }

            return Ok(devices);
        }

        [HttpPost]
        public IActionResult PostDevice([FromBody] Device device)
        {
            _deviceLogic.SaveDevice(device);
            return Ok();
        }

        [HttpGet]
        [Route( "approve/{app}/{registerId}")]
        public IActionResult SetApprove([FromRoute] bool app, int registerId)
        {
            return Ok(_deviceLogic.SetApprove(app, registerId));
        }

        [HttpGet]
        [Route("request/{userId}")]
        public IEnumerable<Register> GetRequests([FromRoute] int userId)
        {
            return _deviceLogic.GetRequests(userId);
        }

        [HttpGet]
        [Route("register/{registerId}")]
        public IActionResult GetSubscription([FromRoute] int registerId)
        {
            _deviceLogic.GetSubscription(registerId);
            return Ok();
        }

        [HttpGet]
        [Route("delete/{deviceId}")]
        public IActionResult DeleteDevice([FromRoute] int deviceId)
        {
            return Ok(_deviceLogic.RemoveDevice(deviceId));
        }
    }
}
