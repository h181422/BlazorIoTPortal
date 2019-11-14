using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTPortal.Model
{
    public interface IDeviceApi
    {
        Task<IEnumerable<Device>> GetDevicesAsync();

        Task<IEnumerable<Device>> GetPublishedDevicesAsync(string searchTerm);

        Task<Device> GetDeviceAsync(string name);

        Task PostDevice(Device device);

    }
}
