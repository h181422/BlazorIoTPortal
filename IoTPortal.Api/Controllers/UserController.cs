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
        [Route("{userIdentification}")]
        public IActionResult GetUser([FromRoute] string userIdentification)
        {
            IoTUser user = int.TryParse(userIdentification, out int a)
                ? _userLogic.GetUser(a)
                : _userLogic.GetUser(userIdentification);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult PostDevice([FromBody] IoTUser user)
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
