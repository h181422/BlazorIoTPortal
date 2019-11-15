using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IoTPortal.UI.Server.Data;
using IoTPortal.Model;
using System.Linq;
using System;
using Logic.Users;

namespace IoTPortal.UI.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController()
        {
            _userLogic = new UserLogic();
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<IoTUser> GetUsers()
        {
            return _userLogic.GetUsers();
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUser([FromRoute] string userId)
        {
            IoTUser user = null;
            int a;
            if (int.TryParse(userId, out a))
            {
                user = _userLogic.GetUser(a);
            }
            else
            {
                user = _userLogic.GetUser(userId);
            }
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] IoTUser user)
        {
            _userLogic.SaveUser(user);
            return Ok();
        }

        [HttpGet]
        [Route("subscribed/{userId}")]
        public IEnumerable<Device> GetSubscribedDevices([FromRoute] string userId)
        {
            int id = int.Parse(userId);
            return _userLogic.GetSubscribedDevices(id);
        }
    }
}
