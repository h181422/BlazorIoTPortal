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
        public IEnumerable<Device> GetDevices() => SampleData.Devices;

        [HttpGet]
        [Route("{name}")]
        public IActionResult GetDevice([FromRoute] string name)
        {
            var baseObj = SampleData.Devices.FirstOrDefault(b => b.Name == name);
            if (baseObj == null)
            {
                return NotFound();
            }

            return Ok(baseObj);
        }

        [HttpPost]
        public IActionResult PostDevice([FromBody] Device device)
        {
            Api.Service.Bus bussen = new Api.Service.Bus();
            bussen.SendMessage(device);
            System.Console.WriteLine("test i api");
            return Ok();
        }
    }
}
