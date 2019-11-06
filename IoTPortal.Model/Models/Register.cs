using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IoTPortal.Model
{
    public class Register
    {
        public int Id { get; set; }
        public IoTUser User { get; set; }
        public Device Dev { get; set; }
        public Boolean Approved { get; set; }
        public string Time { get; set; }
    }

}
