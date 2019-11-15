using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTPortal.Model
{
    public interface IDeviceApi
    {
        Task<IEnumerable<Device>> GetDevicesAsync();

        Task<IEnumerable<Device>> GetPublishedDevicesAsync(string searchTerm);

        Task<Device> GetDeviceAsync(int deviceId);

        Task PostDevice(Device device);

        Task<Register> SetApproved(bool app, int registerId);

        Task<IEnumerable<Register>> GetRequestsAsync(int userId);

        Task<Register> GetSubscriptionAsync(int registerId);

        Task<Device> DeleteDeviceAsync(int deviceId);
    }
}
