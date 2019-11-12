using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IoTPortal.UI.Server.Data;
using IoTPortal.Model;
using System.Linq;
using System;

namespace IoTPortal.UI.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public IEnumerable<IoTUser> GetDevices()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetDevice([FromRoute] string userId)
        {
            int a;
            if (int.TryParse(userId, out a))
            {
                // id
            }
            else
            {
                // username
            }
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult PostDevice([FromBody] IoTUser user)
        {
            throw new NotImplementedException();
        }
    }
}
