using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IoTPortal.Model
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public IoTUser User { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
    }

}
