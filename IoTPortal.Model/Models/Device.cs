using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IoTPortal.Model
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Published { get; set; }
        public string Link { get; set; }
        public string ImageLink { get; set; }
    }

}
