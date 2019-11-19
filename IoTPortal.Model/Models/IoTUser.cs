using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IoTPortal.Model
{
    public class IoTUser
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Device> OwnDevices { get; set; }
        public List<Register> SubscribedDevices { get; set; }
    }

}
