using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IoTPortal.UI.Server.Data;
using IoTPortal.Model;
using System.Linq;

namespace IoTPortal.UI.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public IEnumerable<Device> GetDevices() => SampleData.Devices;

        [HttpGet]
        [Route("{deviceName}")]
        public IActionResult GetDevice([FromRoute] string deviceName)
        {
            var baseObj = SampleData.Devices.FirstOrDefault(b => b.Name == deviceName);
            if (baseObj == null)
            {
                return NotFound();
            }

            return Ok(baseObj);
        }

        [HttpGet]
        [Route("{searchTerm}")]
        public IEnumerable<Device> GetSearchDevice([FromRoute] string searchTerm) => SampleData.Devices.Where(b => b.Published && b.Name.Contains(searchTerm));

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
