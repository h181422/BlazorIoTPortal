using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTPortal.Model
{
    public interface IUserApi
    {
        Task<IEnumerable<IoTUser>> GetUsersAsync();

        Task<IoTUser> GetUserAsync(int userId);

        Task<IoTUser> GetUserAsync(string username);

        Task PostUser(IoTUser user);

        Task<IEnumerable<Device>> GetSubscribedDevicesAsync(int userId);
    }
}
