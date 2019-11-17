using System.Collections.Generic;
using IoTPortal.Model;

namespace Logic.Users
{
    public interface IUserLogic
    {
        void SaveUser(IoTUser user);
        bool RemoveUser(int userId);
        List<IoTUser> GetUsers();
        IoTUser GetUser(int userId);
        IoTUser GetUser(string username);
        List<Register> GetSubscribedDevices(int userId);
        bool Unsubscribe(int userId, int deviceId);

    }
}
