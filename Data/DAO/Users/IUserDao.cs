using System.Collections.Generic;
using IoTPortal.Model;

namespace Data.DAO.Users
{
    public interface IUserDao
    {
        void SaveUser(IoTUser user);
        bool RemoveUser(int userId);
        List<IoTUser> GetUsers();
        IoTUser GetUser(int userId);
        IoTUser GetUser(string username);
        List<Register> GetSubscribedDevices(int userId);
        bool Unsubscribe(int userId, int deviceId);
        IoTUser ValidateLogin(string username, string password);
    }
}
