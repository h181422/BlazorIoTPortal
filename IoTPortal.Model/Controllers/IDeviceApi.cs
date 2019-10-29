using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IoTPortal.Model
{
    public interface IDeviceApi
    {
        Task<IEnumerable<Device>> GetDevicesAsync();

        Task<Device> GetDeviceAsync(string name);

        Task PostDevice(Device device);

        Task<IEnumerable<Device>> GetSubscriptionsAsync();
    }
}
