using IoTPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTPortal.UI.Server.Data
{
    public static class SampleData
    {

        public static List<Device> Devices = new List<Device>
        {
            new Device() { Id = 1, Name = "Temperaturmåler", Published = true,
                ImageLink="https://miro.medium.com/max/1152/0*ceM6ksqq1i2H40Zj.png",
                Link="https://miro.medium.com/max/1152/0*ceM6ksqq1i2H40Zj.png" },
            new Device() { Id = 2, Name = "Vindusvisker", Published = true, 
                ImageLink = "http://hepworthwwt.com/wp-content/uploads/2018/10/IMG_2478-1024x683.jpg",
                Link="http://hepworthwwt.com/wp-content/uploads/2018/10/IMG_2478-1024x683.jpg"},
            new Device() { Id = 3, Name = "IOT-Atomkraftverk", Published = true, 
                ImageLink="https://previews.123rf.com/images/weenvector/weenvector1708/weenvector170800002/83587014-vector"
                +"-isometric-cooling-system-of-a-nuclear-power-plant-isolated-on-white-background-cooling-towers.jpg",
                Link="https://previews.123rf.com/images/weenvector/weenvector1708/weenvector170800002/83587014-vector"
                +"-isometric-cooling-system-of-a-nuclear-power-plant-isolated-on-white-background-cooling-towers.jpg"}
        };

        public static List<Device> Subscriptions = new List<Device>
        {
            new Device() { Id = 1, Name = "Temperaturmåler", Published = true,
                ImageLink="https://miro.medium.com/max/1152/0*ceM6ksqq1i2H40Zj.png",
                Link="https://miro.medium.com/max/1152/0*ceM6ksqq1i2H40Zj.png" },
        };
    }
}
