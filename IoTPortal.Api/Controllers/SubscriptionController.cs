using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IoTPortal.UI.Server.Data;
using IoTPortal.Model;
using System.Linq;

namespace IoTPortal.UI.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Device> GetSubscriptions() => SampleData.Subscriptions;

        [HttpGet]
        [Route("{name}")]
        public IActionResult GetSubscriptions([FromRoute] string name)
        {
            var baseObj = SampleData.Subscriptions.FirstOrDefault(b => b.Name == name);
            if (baseObj == null)
            {
                return NotFound();
            }

            return Ok(baseObj);
        }

        [HttpPost]
        public IActionResult PostDevice([FromBody] Device device)
        {
            SampleData.Subscriptions.Add(device);
            return Ok();
        }
    }
}
