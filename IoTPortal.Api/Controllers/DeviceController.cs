using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IoTPortal.UI.Server.Data;
using IoTPortal.Model;
using System.Linq;
using Logic.Device;

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
        public IEnumerable<Device> GetDevices() => _deviceLogic.GetDevices();

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
<<<<<<< HEAD
            SampleData.Devices.Where(b => b.Published && (b.Name.ToLower()).Contains(searchTerm.ToLower()));
=======
            _deviceLogic.GetDevices(searchTerm, true, true);
>>>>>>> 63c3f7cb1aaf6c812733ce75451f10c4b92b2fc3

        [HttpGet]
        [Route("search")]
        public IEnumerable<Device> GetPublishedDevices() =>
            _deviceLogic.GetDevices(checkPublished: true, true);

        [HttpDelete]
        [Route("{deviceId}")]
        public IActionResult GetPublishedDevices([FromRoute] int deviceId) =>
            Ok(_deviceLogic.GetDevices(true, true));

        [HttpGet]
        [Route("subscribed")]
        public IEnumerable<Device> GetSubscribedDevices() =>
            SampleData.Devices.Where(b => b.Published);

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
            SampleData.Devices.Add(device);
            return Ok();
        }
    }
}
