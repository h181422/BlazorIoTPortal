using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IoTPortal.UI.Server.Data;
using IoTPortal.Model;
using System.Linq;
using System;
using Logic.Users;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace IoTPortal.UI.Server.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IoTUser Login([FromBody]IoTUser user)
        {
            return _userLogic.ValidateLogin(user.Username, user.Password);
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
        [Route("subscribedDevs/{userId}")]
        public IActionResult GetSubscribedDevices([FromRoute] string userId)
        {
            int id = int.Parse(userId);
            return Ok(_userLogic.GetSubscribedDevices(id));
        }

        [HttpGet]
        [Route("unsubscribe/{userId}/{deviceId}")]
        public IActionResult Unsubscribe([FromRoute] int userId, int deviceId)
        {
            return Ok(_userLogic.Unsubscribe(userId, deviceId));

        }
    }
}
