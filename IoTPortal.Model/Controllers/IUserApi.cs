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

        Task<IEnumerable<Register>> GetSubscribedDevicesAsync(int userId);

        Task<bool> Unsubscribe(int userId, int deviceId);
        Task<IoTUser> Login(string username, string password);
        void SaveAuth(string username, string password);
        (string Username, string Password) GetAuth();

    }
}
