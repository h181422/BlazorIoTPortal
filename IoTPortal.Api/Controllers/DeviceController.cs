using Microsoft.AspNetCore.Mvc;
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
            _deviceLogic.GetDevices(searchTerm, true, true);

        [HttpGet]
        [Route("search")]
        public IEnumerable<Device> GetPublishedDevices() =>
            _deviceLogic.GetDevices(checkPublished: true, true);

        [HttpDelete]
        [Route("{deviceId}")]
        public IActionResult GetPublishedDevices([FromRoute] int deviceId) =>
            Ok(_deviceLogic.GetDevices(true, true));

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
