using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IoTPortal.Model.Controllers
{
    public interface IUserApi
    {
        Task<IEnumerable<IoTUser>> GetUsersAsync();

        Task<IoTUser> GetUserAsync(int userId);

        Task<IoTUser> GetUserAsync(string username);

        Task PostUser(IoTUser user);
    }
}
