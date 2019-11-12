using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IoTPortal.Model
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Published { get; set; }
        public string Link { get; set; }
        public string ImageLink { get; set; }
        public bool Online { get; set; }
        public List<Feedback> Feedback { get; set; }
    }

}
